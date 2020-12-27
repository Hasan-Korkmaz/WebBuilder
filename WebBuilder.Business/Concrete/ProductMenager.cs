using Data.Abstract;
using Entity;
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
