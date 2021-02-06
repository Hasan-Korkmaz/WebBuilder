using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class GlobalTextData:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
      
        public List<GlobalTextDataLanguage> GlobalTextDataLanguages { get; set; }
    }
}
