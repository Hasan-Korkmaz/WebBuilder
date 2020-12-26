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
   public class GlobalTextDataMenager : DataService<GlobalTextData, IGlobalTextDataDAL>, IGlobalTextDataService
    {
        private readonly IGlobalTextDataDAL globalTextDataDAL;
        public GlobalTextDataMenager(IGlobalTextDataDAL globalTextDataDAL) : base(globalTextDataDAL)
        {
            this.globalTextDataDAL = globalTextDataDAL;
        }
        public virtual async Task<IResult<string>> GetKeyValue(string key)
        {
            var result = new Result<string>();
            try
            {
                string value = (await globalTextDataDAL.Get(x=> x.Key==key)).Value;
                if (!String.IsNullOrEmpty(value))
                {
                    result.Data = value;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = "Keye bağlı veri getirildi.";
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
                result.Message = "Arama işlemi yapılırken bir hata oluştu";
            }
            return result;
        }

    }
}
