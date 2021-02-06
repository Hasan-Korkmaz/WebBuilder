using Data.Abstract.LanguageAbstracts;
using Data.Concrete.Context;
using Entity.LanguageModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.DataAccesLayers.LanguageDataAccesLayers
{
   public class EfGlobalTextDataLanguageDAL: DataAccessGlobalTemplate<WebBuilderContext, GlobalTextDataLanguage>,  IGlobalTextDataLanguageDAL
    {
        public override async Task DeleteAsync(GlobalTextDataLanguage entity)
        {
            using (WebBuilderContext Context = new WebBuilderContext())
            {

                var state = Context.Entry(entity);
                state.State = EntityState.Deleted;
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    
    }
    
}
