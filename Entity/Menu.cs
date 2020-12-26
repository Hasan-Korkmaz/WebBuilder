using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Menu:BaseEntity
    {
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public string MenuDisplayName { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
