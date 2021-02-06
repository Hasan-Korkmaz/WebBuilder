using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.LanguageModel
{
   public class GlobalTextDataLanguage:BaseEntity
    {
        public string Value { get; set; }
        public int LanguageId { get; set; }
        public int GlobalTextDataId { get; set; }
        public Language Language { get; set; }
        public GlobalTextData GlobalTextData{ get; set; }
    }
}
