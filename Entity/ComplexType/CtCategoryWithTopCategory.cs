using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ComplexType
{
    public class CtCategoryWithTopCategory:BaseEntity
    {
        public string CategoryName { get; set; }
        public string TopCategoryName { get; set; }
        public string Description { get; set; }
    }
}
