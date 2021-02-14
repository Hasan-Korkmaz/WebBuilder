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
    public class EfMenuItemDAL: DataAccessGlobalTemplate<WebBuilderContext, MenuItem>, IMenuItemDAL
    {
        public async override Task<MenuItem> Get(Expression<Func<MenuItem, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.MenuItems
                    .Where(x => x.isDelete == false)
                    .Where(condition ?? (entity => true)).Include(x=> x.MenuItemLanguages).Include(x=> x.MenuItems).Include(x=> x.TopMenuItem)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
