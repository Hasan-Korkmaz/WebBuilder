using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.LanguageModel
{
   public class MenuItemLanguage:BaseEntity
    {
        public string DisplayName { get; set; }
        public int MenuItemId { get; set; }
        public int LanguageId { get; set; }
        public MenuItem MenuItem{ get; set; }
        public Language Language { get; set; }
    }
}
