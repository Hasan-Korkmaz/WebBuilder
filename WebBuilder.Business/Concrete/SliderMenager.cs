using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete
{
    public class SliderMenager : DataService<Slider, ISliderDAL>, ISliderService
    {
        private readonly ISliderDAL sliderDAL;
        public SliderMenager(ISliderDAL sliderDAL) : base(sliderDAL)
        {
            this.sliderDAL = sliderDAL;
        }
        
    }
}
