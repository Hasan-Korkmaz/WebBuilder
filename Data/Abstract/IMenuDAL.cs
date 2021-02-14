using Entity;
using Entity.FrontDataTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IMenuDAL : IDataAccesLayer<Menu>
    {

        public Task<List<MenuItem>> GetMenuItems(int Id);
        public Task<List<MenuWithURL>> GetFullMenu(string tag);

    }
}
