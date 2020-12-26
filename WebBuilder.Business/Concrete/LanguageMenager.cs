using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Entity;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;
using Entity.FrontDataTypes;

namespace WebBuilder.Business.Concrete
{
    //OK
    public class LanguageMenager : DataService<Language, ILanguageDAL>, ILanguageService
    {
        private readonly ILanguageDAL languageDAL;
        public LanguageMenager(ILanguageDAL languageDAL) : base(languageDAL)
        {
            this.languageDAL = languageDAL;
        }
        

        public async Task<IResult<List<LanguageWithUrl>>> GetLanguageURL(Expression<Func<Language, bool>> expression = null)
        {
            var result = new Result<List<LanguageWithUrl>>();
            try
            {
                List<Language> dbObject = await _dataProvider.GetAllAsync(expression);
                if (dbObject != null && dbObject.Count > 0)
                {
                   result.Data=  dbObject.Select(x => new LanguageWithUrl
                    {
                        LanguageShortName = x.ShortName.Split("-")[0].ToUpper(),
                        Url = "/Home/ConfigureLanguage/" + x.ShortName
                    }).ToList();
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = dbObject.Count + "kayıt bulundu listeleniyor.";
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
                result.Message = "Silme işlemi yapılırken bir hata oluştu";
            }
            return result;
        }

    }
}
