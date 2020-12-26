using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public int? TopCategoryId { get; set; }
        public string Description { get; set; }
        public Category? TopCategory { get; set; }
        public virtual List<Category> Children { get; set; }
        public virtual List<CategoryLanguageMap> CategoryLanguageMap { get; set; }
    }
}
