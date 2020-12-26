using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ProductMenager : DataService<Product, IProductDAL>, IProductService
    {
        private readonly IProductDAL productDAL;
        public ProductMenager(IProductDAL productDAL) : base(productDAL)
        {
            this.productDAL = productDAL;
        }
    }
}
