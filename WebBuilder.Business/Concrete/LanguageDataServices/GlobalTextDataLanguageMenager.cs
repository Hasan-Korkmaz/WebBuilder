using Data.Abstract;
using Data.Abstract.LanguageAbstracts;
using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Business.Abstract.LanguageDataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete.LanguageDataServices
{
    public class GlobalTextDataLanguageMenager : DataService<GlobalTextDataLanguage, IGlobalTextDataLanguageDAL>, IGlobalTextDataLanguageService
    {

        private readonly IGlobalTextDataLanguageDAL globalTextDataLanguageDAL;
        public GlobalTextDataLanguageMenager(IGlobalTextDataLanguageDAL globalTextDataLanguageDAL) : base(globalTextDataLanguageDAL)
        {
            this.globalTextDataLanguageDAL = globalTextDataLanguageDAL;
        }
        public override async Task<IResult<GlobalTextDataLanguage>> Delete(GlobalTextDataLanguage entity)
        {
            var result = new Result<GlobalTextDataLanguage>();
            try
            {
                entity.isDelete = true;
                entity.DeletedDate = DateTime.Now;
                await globalTextDataLanguageDAL.DeleteAsync(entity);
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Silme işlemi başarılı bir şekilde gerçekleştirildi.";

            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Silme işlemi yapılırken bir servis hata oluştu.";
            }
            return result;
        }
     
    }
}
