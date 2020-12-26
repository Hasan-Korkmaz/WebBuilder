using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ContactMenager: DataService<Contact, IContactDAL>, IContactService
    {
        private readonly IContactDAL contactDAL;
        public ContactMenager(IContactDAL contactDAL) : base(contactDAL)
        {
            this.contactDAL = contactDAL;
        }
    }
}
