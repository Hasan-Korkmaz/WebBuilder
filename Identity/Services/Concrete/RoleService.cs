using ReskaAPI.Services.Abstract;
using Identity.Models;
using Identity.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.DTO;

namespace ReskaAPI.Services.Concrete
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<APIRole> _roleManager;
        private readonly UserManager<APIUser> _userManager;
        public RoleService(RoleManager<APIRole> roleManager, UserManager<APIUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        //Bütün Rolleri Görme
        public List<RoleDTO> GetAll()
        {
            //List<RoleDTO> roleList = new List<RoleDTO>();

            ////foreach (var model in _roleManager.Roles)
            ////{
            ////    roleList.Add(new RoleDTO
            ////    {
            ////        Name = model.Name,
            ////        Id = model.Id
            ////    });
            ////}

            var roleList = from model in _roleManager.Roles
                           select new RoleDTO
                           {
                               Name = model.Name,
                               Id = model.Id
                           };


            return roleList.ToList();
        }

        //Kullanıcıya ait rolleri görme
        public async Task<List<RoleAssignDTO>> UserRoleShowAsync(string id)
        {
            APIUser user = await _userManager.FindByIdAsync(id).ConfigureAwait(false);

            var assignRoles = from roleName in await _userManager.GetRolesAsync(user).ConfigureAwait(false)
                              select new RoleAssignDTO
                              {
                                  RoleName = roleName,
                                  IsAssign = true,

                              };



            return (assignRoles.ToList());
        }

        /// <summary>
        /// Gelen Role Listesindeki IsAssign true olanlar eklenicek
        /// false olanlar çıkarılacaktır
        /// </summary>
        /// <param name="RoleList"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> UserRoleAddAsync(List<RoleAssignDTO> RoleList, string id)
        {
            //Rollerin eklenip silinmediği kontrol edilecek

            APIUser user = _userManager.FindByIdAsync(id).Result;

            //Kullanıcıya (IsAssign = false ) ait roller siliniyor
            var DeleteRoleResult = await _userManager.RemoveFromRolesAsync(user, RoleList.Where(role => role.IsAssign == false).Select(a => a.RoleName).ToList()).ConfigureAwait(false);


            //Kullanıcıya (IsAssign = true) ait rolle eklenir
            var AddRoleResult = await _userManager.AddToRolesAsync(user, RoleList.Where(role => role.IsAssign == true).Select(a => a.RoleName).ToList()).ConfigureAwait(false);

            if (AddRoleResult.Succeeded) return true;

            return false;
        }



        /*
         public async Task<bool> CreateRoleAsync(RoleDTO model)//Role oluşturma yada update
         {
             IdentityResult result = await _roleManager.CreateAsync(new APIRole { Name = model.Name, CreatedDate = DateTime.Now }).ConfigureAwait(false);
             if (result.Succeeded)
             {
                 return true;
             }
             return false;
         }

         public async Task<bool> DeleteRole(string id)//Role Silme
         {
             APIRole role = await _roleManager.FindByIdAsync(id);
             IdentityResult result = await _roleManager.DeleteAsync(role);
             if (result.Succeeded)
             {
                 return true;
             }
             return false;
         }
         */

    }
}
