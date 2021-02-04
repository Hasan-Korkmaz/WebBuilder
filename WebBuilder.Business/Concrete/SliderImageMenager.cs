using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
   public class SliderImageMenager:DataService<SliderImage, ISliderImageDAL>, ISliderImageService
    {
        private readonly ISliderImageDAL sliderImageDAL;
        public SliderImageMenager(ISliderImageDAL sliderImageDAL) : base(sliderImageDAL)
        {
            this.sliderImageDAL = sliderImageDAL;
        }
    }
}
