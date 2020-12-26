using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.DTO
{
    public class LoginDTO
    {
        public LoginDTO()
        {
            this.ErrorMessages = new List<IdentityError>();//Hata mesajlarını kullanmak için
        }
        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [StringLength(15, ErrorMessage = "Lütfen kullanıcı adınızı 2 ile 15 karakter arasında giriniz...", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
       
        /// <summary>
        /// Beni hatırla...
        /// </summary>
        [Display(Name = "Beni Hatırla")]
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
        public bool IsPersonnel { get; set; }
        public List<IdentityError> ErrorMessages { get; set; }
    }
}
