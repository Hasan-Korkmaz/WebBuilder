﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class SliderImage:BaseEntity
    {
        public string  ImgLocation { get; set; }
        public string AltValue { get; set; }
        public int Order { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
