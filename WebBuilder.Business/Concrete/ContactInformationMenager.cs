using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ContactInformationMenager: DataService<ContactInformation, IContactInformationDAL>, IContactInformationService
    {
        private readonly IContactInformationDAL contactInformationDAL;
        public ContactInformationMenager(IContactInformationDAL contactInformationDAL) : base(contactInformationDAL)
        {
            this.contactInformationDAL = contactInformationDAL;
        }
    }
}
