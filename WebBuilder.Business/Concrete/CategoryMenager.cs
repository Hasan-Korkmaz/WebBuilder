using Data.Abstract;
using Entity;
using Entity.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete
{
    public class CategoryMenager : DataService<Category, ICategoryDAL>, ICategoryService
    {
        private readonly ICategoryDAL categoryDAL;
        public CategoryMenager(ICategoryDAL categoryDAL) : base(categoryDAL)
        {
            this.categoryDAL = categoryDAL;
        }

        public virtual async Task<IResult<List<CtCategoryWithTopCategory>>> GetAllOnlyCategoriesAsync(Expression<Func<Category, bool>> expression = null)
        {
            var result = new Result<List<CtCategoryWithTopCategory>>();
            try
            {
                List<CtCategoryWithTopCategory> dbObject = await _dataProvider.GetAllOnlyCategoriesAsync(expression);
                if (dbObject != null && dbObject.Count > 0)
                {
                    result.Data = dbObject;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = dbObject.Count + " kayıt bulundu listeleniyor.";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message = "Kriterlere göre kayıt bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = " Arama işlemi yapılırken bir hata oluştu";
            }
            return result;
        }

    }
}
