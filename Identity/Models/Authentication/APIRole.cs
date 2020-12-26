using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Models.Authentication
{
    public class APIRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }
        public string PageName { get; set; }
        public string ShowToCustomerName { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }

    }
}
