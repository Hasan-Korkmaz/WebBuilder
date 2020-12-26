using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ContactInformation:BaseEntity
    {
        public string Adress { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
