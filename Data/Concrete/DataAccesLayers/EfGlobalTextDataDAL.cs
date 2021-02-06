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
                    .Where(x =>   x.isDelete == false).Where(condition ?? (entity => true))
                    .Include(x=> x.GlobalTextDataLanguages)
                    .ThenInclude(x=> x.Language)
                    .AsTracking()
                    .FirstOrDefaultAsync()
                    
                    .ConfigureAwait(false);
            }
        }
        public override async Task<List<GlobalTextData>> GetAllAsync(Expression<Func<GlobalTextData, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.GlobalTextDatas
                    .Where(x =>  x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
        public override async Task UpdateAsync(GlobalTextData entity)
        {
            using (var Context = new WebBuilderContext())
            {
                Context.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;

                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public override async Task DeleteAsync(GlobalTextData entity)
        {
            using (var Context = new WebBuilderContext())
            {
                Context.Attach(entity);
                var state = Context.Entry(entity);
                state.State = EntityState.Modified;
                foreach (var item in entity.GlobalTextDataLanguages)
                {
                    Context.Entry(item).State = EntityState.Modified;
                }
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        public  string  GetByTagName(string tag)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {

                return ctx.GlobalTextDataLanguage
                    .Where(x => x.Language.ShortName.Contains(Language) && x.GlobalTextData.Tag.Contains(tag) && x.isDelete == false && x.isActive==true)
                    .Select(x => x.Value).FirstOrDefault();



            }
        }
    }
}
