using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class MenuMenager : DataService<Menu, IMenuDAL>, IMenuService
    {
        private readonly IMenuDAL menuDAL;
        public MenuMenager(IMenuDAL menuDAL) : base(menuDAL)
        {
            this.menuDAL = menuDAL;
        }
    }
}
