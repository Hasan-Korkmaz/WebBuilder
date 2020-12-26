using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Contact:BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }

    }
}
