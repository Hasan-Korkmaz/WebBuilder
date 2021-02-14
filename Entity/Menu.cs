using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Menu:BaseEntity
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public string Tag { get; set; }
        public virtual ICollection<MenuItem> MenuItems{ get; set; }

    }
}
