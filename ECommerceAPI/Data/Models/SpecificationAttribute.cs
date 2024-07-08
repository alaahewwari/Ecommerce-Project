namespace ECommerceAPI.Data.Models
{
    public class SpecificationAttribute
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<AttributeValue> Values { get; set; } = new List<AttributeValue>();
    }
}