namespace ECommerceAPI.Dtos.Product.Responses
{
    public class AttributeResponseDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public AttributeValueResponseDto AttributeValue { get; set; }
    }
}