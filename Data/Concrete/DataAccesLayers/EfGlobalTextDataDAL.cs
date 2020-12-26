using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.DataAccesLayers
{
   public class EfGlobalTextDataDAL : DataAccessGlobalTemplate<WebBuilderContext, GlobalTextData>, IGlobalTextDataDAL
    {
        public override async Task<GlobalTextData> Get(Expression<Func<GlobalTextData, bool>> condition = null)
        {

            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.GlobalTextDatas
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
            }
        }
        public override async Task<List<GlobalTextData>> GetAllAsync(Expression<Func<GlobalTextData, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.GlobalTextDatas
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
