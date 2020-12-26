using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Location:BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Zoom { get; set; }
        public int ContactInformationId { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
    }
}
