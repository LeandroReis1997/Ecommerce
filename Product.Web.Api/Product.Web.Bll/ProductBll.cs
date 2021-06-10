using Product.Web.Bll.Interface;
using Product.Web.Dal.Interface;
using Product.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Web.Bll
{
    public class ProductBll : IProductBll
    {

        private IProductDal dal;
        public ProductBll(IProductDal productDal)
        {
            dal = productDal;
        }
        public Task<ProductInfo> AddProduct(ProductInfo product)
        {
            return dal.AddProduct(product);
        }

        public Task<string> DeleteProduct(string id)
        {
            return dal.DeleteProduct(id);
        }

        public Task<ProductInfo> EditProduct(string id, ProductInfo product)
        {
            return dal.EditProduct(id, product);
        }

        public List<ProductInfo> GetAllProducts()
        {
            return dal.GetAllProducts();
        }

        public ProductInfo GetByName(string name)
        {
            return dal.GetByName(name);
        }

        public ProductInfo GetByProductId(string id)
        {
            return dal.GetByProductId(id);
        }
    }
}
