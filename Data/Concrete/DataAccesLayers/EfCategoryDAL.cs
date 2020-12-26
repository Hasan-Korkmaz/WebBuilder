using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using Entity.ComplexType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.DataAccesLayers
{
    public class EfCategoryDAL: DataAccessGlobalTemplate<WebBuilderContext, Category>, ICategoryDAL
    {
        public override async Task<Category> Get(Expression<Func<Category, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                var query = (from catMap in ctx.CategoryLanguageMap
                             join cat in ctx.Categories.Include(x => x.Children).Where(condition ?? (entity => true)).Where(x => x.isDelete == false) on catMap.CategoryId equals cat.Id
                             join lang in ctx.Languages on catMap.LanguageId equals lang.Id
                             where Language != null ? lang.ShortName.Contains(Language) : true
                             orderby lang.Name
                             select cat);
                return await query.FirstOrDefaultAsync().ConfigureAwait(false);
            }
        }
        public override async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            { 
                var query  =  (from catMap in ctx.CategoryLanguageMap
                             join cat in ctx.Categories.Include(x => x.Children).Where(condition ?? (entity => true)).Where(x=> x.isDelete==false) on catMap.CategoryId equals cat.Id
                             join lang in ctx.Languages on catMap.LanguageId equals lang.Id
                                    where Language!=null ? lang.ShortName.Contains(Language) :true
                                    orderby lang.Name
                             select cat);
                return await query.ToListAsync().ConfigureAwait(false);
            }
        }
        public  async Task<List<CtCategoryWithTopCategory>> GetAllOnlyCategoriesAsync(Expression<Func<Category, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                var query = ctx.Categories
                    .Where(condition ?? (entity => true))
                    .Select(x=> 
                    new CtCategoryWithTopCategory { 
                        Id=x.Id,
                        CategoryName=x.CategoryName,
                        isActive=x.isActive,
                        TopCategoryName=x.TopCategory.CategoryName,
                        Description=x.Description
                    });
                return await query.ToListAsync().ConfigureAwait(false);
            }
        }
    }
}
