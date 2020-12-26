using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBuilder.Business.Abstract.DataServices
{
    public interface IServiceService: IDataService<Service, IServiceDAL>
    {
    }
}
