using Microsoft.AspNetCore.Identity;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    [MySqlCharset("utf8")]
    public class APIUser : IdentityUser<int>
    {
        public string UserTypeId { get; set; }

        [Encrypted]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
    }
}
