namespace ECommerceAPI.Data.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public ICollection<Review> reviews { get; set; } = new List<Review>();

    }
}
