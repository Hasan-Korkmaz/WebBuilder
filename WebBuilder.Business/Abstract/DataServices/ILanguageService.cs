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
    public interface ILanguageService:IDataService<Language,ILanguageDAL>
    {
        Task<IResult<List<LanguageWithUrl>>> GetLanguageURL(Expression<Func<Language, bool>> expression = null);

    }
}
