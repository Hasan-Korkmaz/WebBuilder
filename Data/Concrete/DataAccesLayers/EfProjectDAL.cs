using Data.Abstract;
using Data.Concrete.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.DataAccesLayers
{
    public class EfProjectDAL : DataAccessGlobalTemplate<WebBuilderContext, Project>, IProjectDAL
    {
    }
}
