using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class PhoneNumber : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int ContactInformationId { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }

    }
}
