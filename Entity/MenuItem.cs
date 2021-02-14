using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class MenuItem:BaseEntity
    {
        public string Url{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? TopMenuItemId{ get; set; }
        public int MenuId{ get; set; }
        public MenuItem TopMenuItem { get; set; }
        public Menu Menu { get; set; }
        public ICollection<MenuItem> MenuItems{ get; set; }
        public ICollection<MenuItemLanguage> MenuItemLanguages { get; set; }
    }
}
