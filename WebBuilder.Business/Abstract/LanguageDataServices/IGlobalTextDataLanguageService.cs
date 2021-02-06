using Data.Abstract.LanguageAbstracts;
using Entity.LanguageModel;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Abstract.LanguageDataServices
{
   public interface IGlobalTextDataLanguageService : IDataService<GlobalTextDataLanguage, IGlobalTextDataLanguageDAL>
    {
    }
}
