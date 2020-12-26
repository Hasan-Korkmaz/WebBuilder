using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.DataAccesLayers
{
    public class EfLanguageDAL : DataAccessGlobalTemplate<WebBuilderContext, Language>,ILanguageDAL
    {
    }
}
