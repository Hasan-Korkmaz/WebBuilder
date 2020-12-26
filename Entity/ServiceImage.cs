using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ServiceImage
    {
        public string ImageURL { get; set; }
        public bool isMainImage { get; set; }
        public string ImageAltValue { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
