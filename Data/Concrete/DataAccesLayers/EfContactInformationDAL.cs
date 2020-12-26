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
    public class EfContactInformationDAL : DataAccessGlobalTemplate<WebBuilderContext, ContactInformation>, IContactInformationDAL
    {
        public override async Task<ContactInformation> Get(Expression<Func<ContactInformation, bool>> condition = null)
        {
            using (WebBuilderContext Context = new WebBuilderContext())
            {
                return await Context.Set<ContactInformation>().Where(entity => entity.isDelete == false)
            .Where(condition ?? (entity => true)).Include(x=> x.PhoneNumbers).Include(x=>x.SocialMedias).Include(x => x.Locations)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

            }
        }
        public override async Task<List<ContactInformation>> GetAllAsync(Expression<Func<ContactInformation, bool>> condition = null)
        {
            using (WebBuilderContext Context = new WebBuilderContext())
            {
                return await Context.Set<ContactInformation>().Where(entity => entity.isDelete == false)
            .Where(condition ?? (entity => true)).Include(x => x.PhoneNumbers).Include(x => x.SocialMedias).Include(x => x.Locations)
            .ToListAsync()
            .ConfigureAwait(false);
            }
        }
        public override async Task<ContactInformation> GetByIdAsync(int id)
        {
            using (WebBuilderContext Context = new WebBuilderContext())
            {
                return await Context.Set<ContactInformation>().Where(entity => entity.isDelete == false)
            .Where(x=> x.Id==id).Include(x => x.PhoneNumbers).Include(x => x.SocialMedias).Include(x => x.Locations)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);
            }
        }
    }
}
