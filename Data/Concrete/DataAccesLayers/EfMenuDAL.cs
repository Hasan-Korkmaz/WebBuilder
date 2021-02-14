using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using Entity.FrontDataTypes;
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
                    .Where(x =>  x.isDelete == false)
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
                    .Where(x =>  x.isDelete == false)
                    .Where(condition ?? (entity => true))
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }

        public async Task<List<MenuWithURL>> GetFullMenu(string tag)
        {
            using (WebBuilderContext ctx = new WebBuilderContext())
            {
                var q = ctx.Menus.Where(x => x.isDelete == false && x.Tag.Contains(tag)).FirstOrDefault();
                var qx = ctx.Languages.Where(x => x.isDelete == false && x.ShortName.Contains(Language)).FirstOrDefault();
               
                
              var data=      ctx.MenuItems.Where(x => x.MenuId == q.Id && x.isDelete==false && x.isActive==true && x.MenuItemLanguages.Any(x=> x.LanguageId==qx.Id)).Include(x=> x.MenuItemLanguages).OrderBy(x=> x.TopMenuItemId).ToList();
                List<MenuWithURL> menuItems = new List<MenuWithURL>();
                foreach (var item in data)
                {
                    MenuWithURL top=null;
                    if (item.TopMenuItem!=null)
                    {
                         top = menuItems.Where(x => x.MenuName == item.TopMenuItem.Name).FirstOrDefault();
                        if (menuItems.Where(x => x.MenuName == item.TopMenuItem.Name).FirstOrDefault() != null)
                        {
                            top.AltMenu.Add(new MenuWithURL() { MenuName = item.MenuItemLanguages.First().DisplayName, MenuLink = item.Url });
                        }
                       
                    }
                    else
                    {
                        menuItems.Add(new MenuWithURL() { MenuName = item.MenuItemLanguages.First().DisplayName, MenuLink = item.Url });

                    }
                }
                return menuItems;
                
                    
            }
        }
        public  async Task<List<MenuItem>> GetMenuItems(int Id)
        {
            
                using (WebBuilderContext ctx = new WebBuilderContext())
                {
                    return await ctx.MenuItems
                        .Where(x => x.isDelete == false)
                        .Where(x=> x.MenuId==Id ).Include(x=> x.MenuItemLanguages).Include(x=> x.TopMenuItem)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
        }

    }
}
