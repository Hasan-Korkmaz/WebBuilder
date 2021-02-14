using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete
{
    public class MenuMenager : DataService<Menu, IMenuDAL>, IMenuService
    {
        private readonly IMenuDAL menuDAL;
        public MenuMenager(IMenuDAL menuDAL) : base(menuDAL)
        {
            this.menuDAL = menuDAL;
        }

        public async Task<IResult<List<Entity.FrontDataTypes.MenuWithURL>>> FullMenuByTag(string tag)
        {
            var result = new Result<List<Entity.FrontDataTypes.MenuWithURL>>();
            try
            {
                var value = await menuDAL.GetFullMenu(tag);
                if (value != null)
                {
                    result.Data = value;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = value.Count + "Adet Menü Öğesi Bulundu";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message = "Kriterlere göre kayıt bulunamadı.";
                    result.Data = null;
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Arama işlemi yapılırken bir hata oluştu";
                result.Data = null;

            }

            return result;
        }

        public async Task<IResult<List<MenuItem>>> GetMenuItems(int Id)
        {

            var result = new Result<List<MenuItem>>();
            try
            {
                var value = await menuDAL.GetMenuItems(Id);
                if (value!=null)
                {
                    result.Data = value;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = value.Count+  "Adet Menü Öğesi Bulundu";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message = "Kriterlere göre kayıt bulunamadı.";
                    result.Data = null;
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Arama işlemi yapılırken bir hata oluştu";
                result.Data = null;

            }
      
            return result;
        }
    }
}
