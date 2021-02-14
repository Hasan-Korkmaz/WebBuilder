using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete
{
   public class GlobalImageService : DataService<GlobalImage, IGlobalImage>, IGlobalImageService
    {
        private readonly IGlobalImage globalImageDAL;
        public GlobalImageService(IGlobalImage globalImageDAL) : base(globalImageDAL)
        {
            this.globalImageDAL = globalImageDAL;
        }
        
        public async Task<IResult<GlobalImage>> GetByTagName(string tag)
        {
            var result = new Result<GlobalImage>();
            try
            {
                var value =  globalImageDAL.GetByTagName(tag).Result;
                if (value!=null)
                {
                    result.Data = value;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = "Tag bağlı veri getirildi.";
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
