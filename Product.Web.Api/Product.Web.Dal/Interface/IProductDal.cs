using Product.Web.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Web.Dal.Interface
{
    public interface IProductDal
    {
        List<ProductInfo> GetAllProducts();
        ProductInfo GetByProductId(string id);
        List<ProductInfo> GetByName(string name);
        Task<ProductInfo> AddProductAsync(ProductInfo product);
        Task<ProductInfo> EditProductAsync(string id, ProductInfo product);
        Task<string> DeleteProduct(string id);
    }
}
