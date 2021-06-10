using MongoDB.Driver;
using Product.Web.Dal.Interface;
using Product.Web.Info;
using Product.Web.Info.Data.Configuration.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Web.Dal
{
    public class ProductDal : IProductDal
    {
        private readonly IMongoCollection<ProductInfo> _products;

        public ProductDal(IProductStoreDatabaseSettings configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            var database = client.GetDatabase(configuration.DatabaseName);
            _products = database.GetCollection<ProductInfo>(configuration.ProductCollectionName);
        }

        public async Task<ProductInfo> AddProduct(ProductInfo product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }

        public async Task<string> DeleteProduct(string id)
        {
            await _products.DeleteOneAsync(x => x.Id == id);
            return id;
        }

        public async Task<ProductInfo> EditProduct(string id, ProductInfo product)
        {
            await _products.ReplaceOneAsync(x => x.Id == id, product);
            return product;
        }

        public List<ProductInfo> GetAllProducts()
        {
            return _products.Find(x => true).ToList();
        }

        public ProductInfo GetByName(string name)
        {
            return _products.Find<ProductInfo>(x => x.NameProduct == name).FirstOrDefault();
        }

        public ProductInfo GetByProductId(string id)
        {
            return _products.Find<ProductInfo>(x => x.Id == id).FirstOrDefault();
        }
    }
}
