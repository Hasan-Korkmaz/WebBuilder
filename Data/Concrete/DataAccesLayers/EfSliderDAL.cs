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
        public override async Task<Slider> Get(Expression<Func<Slider, bool>> condition = null)
        {

            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Sliders
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
            }
        }
        public override async Task<List<Slider>> GetAllAsync(Expression<Func<Slider, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Sliders
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
