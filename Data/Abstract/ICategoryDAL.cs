using Entity;
using Entity.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface ICategoryDAL : IDataAccesLayer<Category>
    {
        Task<List<CtCategoryWithTopCategory>> GetAllOnlyCategoriesAsync(Expression<Func<Category, bool>> condition = null);
    }
}
