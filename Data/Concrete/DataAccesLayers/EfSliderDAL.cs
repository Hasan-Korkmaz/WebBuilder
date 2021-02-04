using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.DataAccesLayers
{
    public class EfSliderDAL : DataAccessGlobalTemplate<WebBuilderContext, Slider>, ISliderDAL
    {
        public async override Task<Slider> Get(Expression<Func<Slider, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                var query = ctx.Sliders.Include(x => x.SliderImages).Where(condition ?? (entity => true));
                return await query.FirstOrDefaultAsync().ConfigureAwait(false);
            }
           
        }

        public async override Task<List<Slider>> GetAllAsync(Expression<Func<Slider, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                var query = ctx.Sliders.Include(x => x.SliderImages).Where(condition ?? (entity => true));
                return await query.ToListAsync().ConfigureAwait(false);
            }
        }
       

    }
}
