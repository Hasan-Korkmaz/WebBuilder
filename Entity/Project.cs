using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Project:BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectContent { get; set; }
        public virtual ICollection<ProjectImage> ProjectImage { get; set; }
    }
}
