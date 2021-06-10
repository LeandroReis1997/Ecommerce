using Product.Web.Info.Data.Configuration.Interface;

namespace Product.Web.Info.Data.Configuration
{
    public class ProductStoreDatabaseSettings : IProductStoreDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
