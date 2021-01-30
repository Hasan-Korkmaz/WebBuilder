using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class Slider:BaseEntity
    {
        public string SliderName { get; set; }
        public string SliderDescription { get; set; }
        public string SliderTag { get; set; }
        public virtual List<SliderImage> SliderImages { get; set; }

    }
}
