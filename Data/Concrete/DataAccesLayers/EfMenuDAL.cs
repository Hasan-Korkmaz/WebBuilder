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
    public class EfMenuDAL : DataAccessGlobalTemplate<WebBuilderContext, Menu>, IMenuDAL
    {

        public override async Task<Menu> Get(Expression<Func<Menu, bool>> condition = null)
        {

            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Menus
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
            }
        }
        public override async Task<List<Menu>> GetAllAsync(Expression<Func<Menu, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Menus
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
