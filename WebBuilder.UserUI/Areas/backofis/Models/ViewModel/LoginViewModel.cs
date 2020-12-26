using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBuilder.UserUI.Areas.backofis.Models.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? CaptchaCode { get; set; }
    }
}
