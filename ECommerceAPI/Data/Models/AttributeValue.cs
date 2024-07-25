namespace ECommerceAPI.Data.Models
{
    public class AttributeValue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
    }
}