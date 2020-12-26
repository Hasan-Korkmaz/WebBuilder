using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ProductImageMenager : DataService<ProductImage, IProductImageDAL>,IProductImageService 
    {
        private readonly IProductImageDAL productImageDAL;
        public ProductImageMenager(IProductImageDAL productImageDAL) : base(productImageDAL)
        {
            this.productImageDAL = productImageDAL;
        }
    }
}
