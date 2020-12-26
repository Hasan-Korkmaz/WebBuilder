using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ProjectImage: BaseEntity
    {
        public string ImageURL { get; set; }
        public bool isMainImage { get; set; }
        public string ImageAltValue { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
