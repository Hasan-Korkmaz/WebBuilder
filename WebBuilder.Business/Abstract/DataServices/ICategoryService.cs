using Data.Abstract;
using Entity;
using Entity.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Abstract.DataServices
{
    public interface ICategoryService : IDataService<Category, ICategoryDAL>
    {
        Task<IResult<List<CtCategoryWithTopCategory>>> GetAllOnlyCategoriesAsync(Expression<Func<Category, bool>> condition = null);
    }
}
