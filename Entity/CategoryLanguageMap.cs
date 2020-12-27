using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class CategoryLanguageMap
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public Category Category { get; set; }
    }
}
