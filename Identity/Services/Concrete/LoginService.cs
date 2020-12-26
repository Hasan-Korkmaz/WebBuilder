using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ReskaAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using Identity.DTO;
using WebBuilderExceptionLibrary;
using Identity.Enums;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ReskaAPI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        readonly UserManager<APIUser> _userManager;
        readonly SignInManager<APIUser> _signInManager;
        private readonly TokenManagement _tokenManagement;
        public LoginService(UserManager<APIUser> userManager, SignInManager<APIUser> signInManager, IOptions<TokenManagement> tokenManagement)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenManagement = tokenManagement.Value;
        }

        public async Task<List<APIUser>> GetUserAsync()
        {
            return await _userManager.Users.ToListAsync().ConfigureAwait(false);
        }

        public async Task<APIUserDTO> SignUpAsync(APIUserDTO apiUserDTO)
        {
            if (apiUserDTO == null) throw new NullParameterException();

            APIUser apiUser = new APIUser
            {
                UserName = apiUserDTO.UserName,
                Email = apiUserDTO.Email,
                UserTypeId = apiUserDTO.UserTypeId
            };
            IdentityResult result = await _userManager.CreateAsync(apiUser, apiUserDTO.Password).ConfigureAwait(false);

            if (result.Errors.Any())
                apiUserDTO.ErrorMessages = result.Errors.ToList();
            return apiUserDTO;
        }

        //Giriş Başarılı ise Token üretilecek , Token username,usertype ve rollere göre değişiyor
        public async Task<Object> SignInAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null) throw new NullParameterException();

            //UserName göre kullanıcı bulunuyor
            APIUser user = await _userManager.FindByNameAsync(userName: loginDTO.UserName)
                .ConfigureAwait(false);

            string lockedMessage = "Art arda 5 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kilitlenmiştir.";//Startupda değiştirebilir

            //User'a ait token var ise ve Hala geçirli ise token üretilmeyecek başka bir uygulamada hesabı açık olduğundan dolayı
            if (user != null)
            {

                //Kullanıcıya ait token alınır
                string TokenInDatabaseForUser = await _userManager.GetAuthenticationTokenAsync(
                    user: user,
                    loginProvider: LoginProviderEnum.Opsiyon.ToString(),
                    tokenName: TokenTypeEnum.AccessToken.ToString()
                    ).ConfigureAwait(false);

                //Eğer Token var ise Geçerlilik zamanı kontrol edilir
                if (TokenInDatabaseForUser != null)
                {
                    //Token geçerlikilik zamanı kontrol ediilir, eğer hala token geçerli ise yeni token üretilmez, Diğer hesaplardan çıkış yapılması istenir
                    if (DateTime.Now < (DateTime)ValidateTokenGetExpiredTime(TokenInDatabaseForUser))
                    {
                        loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("MultipleAccountsException", "Diğer hesaplarınızdan çıkış yapınız"));

                        return loginDTO;
                    }
                }

                await _signInManager.SignOutAsync().ConfigureAwait(false);//İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.

                //UserName ve Şifreye göre Kimlik Doğrulama
                SignInResult result = await _signInManager
                    .PasswordSignInAsync(
                    user: user,
                    password: loginDTO.Password,
                    isPersistent: loginDTO.Persistent,
                    lockoutOnFailure: loginDTO.Lock
                    ).ConfigureAwait(false);


                if (result.Succeeded)//Kimlik doğrulama başarılı ise
                {
                    await _userManager.ResetAccessFailedCountAsync(user).ConfigureAwait(false); //Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.

                    //Token username,IsPersonnel ve rollere göre üretilir
                    var token = await GenerateTokenWithRoleAsync(IsPersonnel: loginDTO.IsPersonnel, user: user).ConfigureAwait(false);

                    return token;

                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        var lockoutTime = await _userManager.GetLockoutEndDateAsync(user).ConfigureAwait(false);//locklanmış kullanıcının lock süresini alıyoruz

                        if (DateTime.Now > lockoutTime.Value.DateTime)//lock süresi ile şimdiki süreyi karşılaştırma
                        {
                            await _userManager.SetLockoutEndDateAsync(user, null).ConfigureAwait(false);//Locklanmış kullanıcının süresini sıfırlıyoruz

                            SignInResult afterResult = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, loginDTO.Persistent, loginDTO.Lock).ConfigureAwait(false);//tekrar giriş kontrolü

                            if (result.Succeeded)//Giriş doğru ise token üretecek
                            {
                                await _userManager.ResetAccessFailedCountAsync(user).ConfigureAwait(false); //Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.

                                //Token username,IsPersonnel ve rollere göre üretilir
                                var token = await GenerateTokenWithRoleAsync(IsPersonnel: loginDTO.IsPersonnel, user: user).ConfigureAwait(false);

                                return token;
                            }
                            else
                            {
                                await _userManager.AccessFailedAsync(user).ConfigureAwait(false); //Eğer ki başarısız bir account girişi söz konusu ise AccessFailedCount kolonundaki değer +1 arttırılacaktır. 

                                loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("NotValidUser2", "E-posta veya Şifre yanlış!"));
                            }
                        }
                        else
                        {
                            loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("Locked", lockedMessage));//Locklandığı için lock mesaj gösterilmcek
                        }
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user).ConfigureAwait(false); //Eğer ki başarısız bir account girişi söz konusu ise AccessFailedCount kolonundaki değer +1 arttırılacaktır. 

                        loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("NotValidUser2", "E-posta veya Şifre yanlış!"));
                    }
                }
            }
            else
            {
                loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("NotValidUser", "Böyle bir kullanıcı yok!"));
                loginDTO.ErrorMessages.Add(CreateIdentityErrorMessage("NotValidUser2", "E-posta veya Şifre yanlış!"));
            }

            return loginDTO;

        }
        private IdentityError CreateIdentityErrorMessage(string code, string description)
        {
            IdentityError error = new IdentityError();
            error.Code = code;
            error.Description = description;
            return error;
        }
        public async Task<string> DeleteUserAsync(APIUserDTO aPIUserDTO)
        {
            if(aPIUserDTO == null) throw new NullParameterException();

            await _signInManager.SignOutAsync().ConfigureAwait(false);

            APIUser apiUser = await _userManager.FindByNameAsync(aPIUserDTO.UserName).ConfigureAwait(false);

            if (apiUser != null)
            {
                await _userManager.DeleteAsync(apiUser).ConfigureAwait(false);
                return "Ok";
            }
            else
            {
                return "Böyle bir kullanıcı yok!";
            }
        }

        /// <summary>
        /// User tipine göre roller eklenip, token üretilir
        /// </summary>
        /// <param name="IsPersonnel"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<object> GenerateTokenWithRoleAsync(bool IsPersonnel, APIUser user)
        {
            if (user != null)
            {
                IList<string> roles;

                if (IsPersonnel == true)//Personel ise Rollerine göre Token üretilecek
                {
                    roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);//Kullanıcıya ait Roller getirir

                }
                else
                //Personel değil ise sadece LOCALCUSTOMER rolü eklnecektir
                {
                    roles = new List<string> { "LOCALCUSTOMER" };
                }

                string newToken = GenerateToken(UserName: user.UserName, Roles: roles, IsPersonnel: IsPersonnel);

                //Token veritabanını,user idye göre yazılıyor
                IdentityResult identityResult = await _userManager.
                   SetAuthenticationTokenAsync(
                    user: user,
                    loginProvider: LoginProviderEnum.Opsiyon.ToString(),//Token nerede kullanılcak
                    tokenName: TokenTypeEnum.AccessToken.ToString(),//Token tipi
                    tokenValue: newToken
                    ).ConfigureAwait(false);

                if (identityResult.Succeeded) return newToken;
            }

            return null;
        }

        // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
        public string GenerateToken(string UserName, IList<string> Roles, bool IsPersonnel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var ClaimsIdentityList = new ClaimsIdentity();

            //Kullanıcıya ait roller Tokene Claim olarak ekleniyor
            for (int i = 0; i < Roles.Count; i++)
            {
                ClaimsIdentityList.AddClaim(
                     new Claim(ClaimTypes.Role, Roles[i])
                    );
            }

            //Kullanıcını UserName 'i tokena claim olarak ekleniyor
            ClaimsIdentityList.AddClaim(
                    new Claim(ClaimTypes.Name, UserName)
                   );

            //Kullanıcı personnel ise 1 günlük token , değil ise 2 saatlik token verilecektir
            DateTime ExpiredTime;
            if (IsPersonnel)
            {
                ExpiredTime = DateTime.UtcNow.AddDays(1);
            }
            else
            {
                ExpiredTime = DateTime.UtcNow.AddHours(2);
            }

            //Kullanıcını UserName 'i tokena claim olarak ekleniyor
            ClaimsIdentityList.AddClaim(
                    new Claim(ClaimTypes.
                    Expired, value: ExpiredTime.ToString())
                   );

            //Token üretimi için gerekli bilgiler , _tokenManagement => appsettings.json dosyasını okur
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ClaimsIdentityList,
                Issuer = _tokenManagement.Issuer,
                Audience = _tokenManagement.Audience,
                Expires = ExpiredTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenManagement.Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);//Token Üretini

            return tokenHandler.WriteToken(token);
        }

        /* Token ile ilgili
                   issuer: kısacası tokenin oluşturulmasıyla ilintili servis.
                   audience: tokenin kullanılacağı servis.
                   exp: tokenin son valid olduğu tarih.
                   nbf: tokenin aktif olmaya başlayacağı tarih.
                   iat: tokenin oluşturulduğu tarih             
            */

        //Token'ın Decode İşlemi, Token Decode ederek içindeki zamanı döndürür
        public Object ValidateTokenGetExpiredTime(string token)
        {
            //Tokenin içindeli claimları döndürür
            ClaimsPrincipal principal = GetPrincipalForAccessToken(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim ExpiredTimeClaim = identity.FindFirst(ClaimTypes.Expired);

            DateTime Expired = Convert.ToDateTime(value: ExpiredTimeClaim.Value);

            return Expired;//tokenın içindeki username döndürür
        }

        //Token decode işlemi için, token içindeki Claimları döndürür
        private ClaimsPrincipal GetPrincipalForAccessToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;

                //_tokenManagement => appsettings.json dosyasını okur
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenManagement.Issuer,
                    ValidAudience = _tokenManagement.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenManagement.Secret))
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);

                return principal;//Token içindeki gerekli bilgiler döndürülür
            }
            catch (Exception)
            {
                return null;
            }
        }

        /* Kullanılmıyacak burda
        public async Task<bool> PasswordReset(APIUserDTO model)
        {
            APIUser user = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress("alikeskin@milvasoft.com", "MilvaSoft Yazılım Şirketi", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                //mail.Body = $"<a target=\"_blank\" href=\"https://localhost:5001{Url.Action("UpdatePassword", "User", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44360/api/product/GetProduct\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;

                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential("alikeskin@milvasoft.com", "****");
                smp.Port = 587;
                smp.Host = "ni-eagle.guzelhosting.com";
                smp.EnableSsl = true;
                smp.Send(mail);

                return true;
            }
            else
                return false;
        }
        */
    }
}
