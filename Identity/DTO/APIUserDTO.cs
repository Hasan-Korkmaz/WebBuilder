using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.DTO
{
    public class APIUserDTO
    {
        [StringLength(15, ErrorMessage = "Lütfen kullanıcı adınızı 2 ile 15 karakter arasında giriniz...", MinimumLength = 2)]
        public string UserName { get; set; }


        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email giriniz...")]
        public string Email { get; set; }


        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        public string Password { get; set; }

        public string Name { get; set; }

        public string  Surname { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public string PhoneNumber { get; set; }
        public string UserTypeId { get; set; }

        public List<IdentityError> ErrorMessages { get; set; }
    }
}
