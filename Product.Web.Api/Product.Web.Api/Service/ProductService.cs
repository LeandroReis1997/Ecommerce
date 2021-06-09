using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Product.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Web.Api.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<ProductModel> _products;

        public ProductService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("db_ecommerce"));
            var database = client.GetDatabase("db_ecommerce");
            _products = database.GetCollection<ProductModel>("Produto");
        }

        public List<ProductModel> Get()
        {
            return _products.Find(x => true).ToList();
        }

        public ProductModel GetById(string id)
        {
            return _products.Find<ProductModel>(x => x.Id == id).FirstOrDefault();
        }

        public ProductModel Create(ProductModel product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, ProductModel product)
        {
            _products.ReplaceOne(x => x.Id == id, product);
        }

        public void Remove(ProductModel product)
        {
            _products.DeleteOne(x => x.Id == product.Id);
        }

        public void Remove(string id)
        {
            _products.DeleteOne(x => x.Id == id);
        }
    }
}
