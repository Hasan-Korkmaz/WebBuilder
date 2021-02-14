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
    public class EfGlobalImageL : DataAccessGlobalTemplate<WebBuilderContext, GlobalImage>, IGlobalImage
    {
        public async Task<GlobalImage> GetByTagName(string tag)
        {

            using (WebBuilderContext ctx = new WebBuilderContext())
            {

                return await ctx.GlobalImages.Where(x => x.isDelete == false && x.isActive == true).FirstOrDefaultAsync();
            }
            }
        
    }
}
