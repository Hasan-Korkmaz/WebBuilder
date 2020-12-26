using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Models;
using Identity.DTO;

namespace ReskaAPI.Services.Abstract
{
    public interface ILoginService
    {
        Task<APIUserDTO> SignUpAsync(APIUserDTO aPIUserDTO);
        Task<Object> SignInAsync(LoginDTO loginDTO);
        Task<string> DeleteUserAsync(APIUserDTO aPIUserDTO);
        Task<List<APIUser>> GetUserAsync();
    }
}
