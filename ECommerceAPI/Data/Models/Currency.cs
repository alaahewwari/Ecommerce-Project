namespace ECommerceAPI.Data.Models
{
    public class Currency
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
