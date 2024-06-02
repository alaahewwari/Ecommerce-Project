namespace ECommerceAPI.Data.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
