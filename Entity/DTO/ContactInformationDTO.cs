using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class ContactInformationDTO
    {
        public string Adress { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
