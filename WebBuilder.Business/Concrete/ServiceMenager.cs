using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ServiceMenager: DataService<Service, IServiceDAL>, IServiceService
    {
        private readonly IServiceDAL serviceDAL;
        public ServiceMenager(IServiceDAL serviceDAL) : base(serviceDAL)
        {
            this.serviceDAL = serviceDAL;
        }
    }
}
