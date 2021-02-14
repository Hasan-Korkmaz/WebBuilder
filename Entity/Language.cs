using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class Language:BaseEntity
    {
        public string Name { get; set; }
        public string  ShortName { get; set; }
        public virtual ICollection<GlobalTextData> GlobalTextData { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<CategoryLanguageMap> LanguageMaps { get; set; }
        public virtual ICollection<Product> Products{ get; set; }
        public virtual ICollection<MenuItemLanguage> MenuItemLanguages{ get; set; }
    }
}
