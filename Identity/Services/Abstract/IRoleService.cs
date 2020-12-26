using Identity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReskaAPI.Services.Abstract
{
    public interface IRoleService
    {
        List<RoleDTO> GetAll();
        Task<List<RoleAssignDTO>> UserRoleShowAsync(string id);
        Task<object>  UserRoleAddAsync(List<RoleAssignDTO> modelList, string id);
    }
}
