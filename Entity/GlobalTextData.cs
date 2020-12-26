using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class GlobalTextData:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
