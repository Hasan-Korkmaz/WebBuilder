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
    public class EfProductDAL : DataAccessGlobalTemplate<WebBuilderContext, Product>, IProductDAL
    {

        public override async Task<Product> Get(Expression<Func<Product, bool>> condition = null)
        {

            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Products
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true)).Include("ProductImages")
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
            }
        }
        public override async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> condition = null)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                return await ctx.Products
                    .Where(x => x.Language.ShortName.Contains(Language) && x.isDelete == false)
                    .Where(condition ?? (entity => true)).Include("ProductImages")
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
