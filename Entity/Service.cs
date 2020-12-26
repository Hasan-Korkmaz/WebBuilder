using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Service:BaseEntity
    {
        public string ServiceName { get; set; }
        public string ServiceContent { get; set; }
        public virtual ICollection<ServiceImage> ServiceImage { get; set; }
    }
}
