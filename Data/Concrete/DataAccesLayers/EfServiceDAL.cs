using Data.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Data.Abstract;

namespace Data.Concrete.DataAccesLayers
{
    public class EfServiceDAL: DataAccessGlobalTemplate<WebBuilderContext, Service>, IServiceDAL
    {
    }
}
