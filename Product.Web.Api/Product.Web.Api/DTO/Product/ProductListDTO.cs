namespace Product.Web.Api.DTO.Product
{
    public class ProductListDTO
    {
        public string Id { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
    }
}
