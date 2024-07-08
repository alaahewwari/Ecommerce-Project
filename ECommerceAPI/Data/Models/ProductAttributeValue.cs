using ECommerceAPI.Dtos.Product.Responses;

namespace ECommerceAPI.Data.Models
{
    public class ProductAttributeValue
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long AttributeValueId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public AttributeValue AttributeValue { get; set; }
    }
}