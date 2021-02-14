using Data.Abstract;
using Entity;
using Entity.FrontDataTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Abstract.DataServices
{
    public interface IMenuService : IDataService<Menu, IMenuDAL>
    {

        public Task<IResult<List<MenuItem>>> GetMenuItems(int Id);
        public Task<IResult<List<MenuWithURL>>> FullMenuByTag(string tag);
    }

}
