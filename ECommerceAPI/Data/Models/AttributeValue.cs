namespace ECommerceAPI.Data.Models
{
    public class AttributeValue
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long SpecificationAttributeId { get; set; }
        public SpecificationAttribute SpecificationAttribute { get; set; }
        public ICollection<ProductAttributeValue> Values { get; set; } = new List<ProductAttributeValue>();
    }
}
