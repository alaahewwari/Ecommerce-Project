namespace ECommerceAPI.Data.Models
{
    public class PaymentMethod
    {
        public long Id { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public byte ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public string SecurityCode { get; set; }
        public decimal TotalAmount { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }

    }
}
