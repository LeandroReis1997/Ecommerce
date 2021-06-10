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

        public async Task<ProductInfo> AddProductAsync(ProductInfo product)
        {
            return await dal.AddProductAsync(product);
        }

        public Task<string> DeleteProduct(string id)
        {
            return dal.DeleteProduct(id);
        }

        public async Task<ProductInfo> EditProductAsync(string id, ProductInfo product)
        {
            product.Id = id;
            return await dal.EditProductAsync(id, product);
        }

        public List<ProductInfo> GetAllProducts()
        {
            return dal.GetAllProducts();
        }

        public List<ProductInfo> GetByName(string name)
        {
            return dal.GetByName(name);
        }

        public ProductInfo GetByProductId(string id)
        {
            return dal.GetByProductId(id);
        }
    }
}
