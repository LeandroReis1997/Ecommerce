using Product.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Web.Dal.Interface
{
    public interface IProductDal
    {
        List<ProductInfo> GetAllProducts();
        ProductInfo GetByProductId(string id);
        ProductInfo GetByName(string name);
        Task<ProductInfo> AddProduct(ProductInfo product);
        Task<ProductInfo> EditProduct(string id, ProductInfo product);
        Task<string> DeleteProduct(string id);
    }
}
