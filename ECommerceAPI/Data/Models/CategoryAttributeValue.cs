namespace ECommerceAPI.Data.Models
{
    public class CategoryAttributeValue
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long ProductId { get; set; }
        public long ProductAttributeId { get; set; }
        public Product Product { get; set; }
        public CategoryAttribute ProductAttribute { get; set; }
    }
}
