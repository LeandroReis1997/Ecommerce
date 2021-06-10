using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Web.Info
{
    public  class ProductInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
    }
}
