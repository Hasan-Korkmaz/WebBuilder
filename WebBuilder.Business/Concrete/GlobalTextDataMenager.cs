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
        public virtual async Task<IResult<string>> GetKeyValue(string tag)
        {
            var result = new Result<string>();
            try
            {
                string value =  globalTextDataDAL.GetByTagName(tag);
                if (!String.IsNullOrEmpty(value))
                {
                    result.Data = value;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = "Tag bağlı veri getirildi.";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message = "Kriterlere göre kayıt bulunamadı.";
                    result.Data = "Tanımsız.";
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Arama işlemi yapılırken bir hata oluştu";
                result.Data = "Error";

            }
            return result;
        }
        public override async Task<IResult<GlobalTextData>> Delete(GlobalTextData entity)
        {
            var result = new Result<GlobalTextData>();
            try
            {
                if (entity.GlobalTextDataLanguages!=null)
                {
                    entity.GlobalTextDataLanguages.ForEach(x => x.isDelete = true);

                }
                entity.isDelete = true;
                entity.DeletedDate = DateTime.Now;
                await globalTextDataDAL.DeleteAsync(entity);
                
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Silme işlemi başarılı bir şekilde gerçekleştirildi.";
               


            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Silme işlemi yapılırken bir hata oluştu";

            }
            return result;
        }

    }
}
