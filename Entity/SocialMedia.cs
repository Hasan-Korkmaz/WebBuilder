using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Entity
{
    public class SocialMedia:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ContactInformationId { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
    }
}
