using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
   public class MenuItemMenager:DataService<MenuItem, IMenuItemDAL>, IMenuItemService
    {
        private readonly IMenuItemDAL menuItemDAL;
        public MenuItemMenager(IMenuItemDAL menuItemDAL) : base(menuItemDAL)
        {
            this.menuItemDAL = menuItemDAL;
        }
    }
}
