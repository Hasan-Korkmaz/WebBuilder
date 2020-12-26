using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class Slider:BaseEntity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string AltValue { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
