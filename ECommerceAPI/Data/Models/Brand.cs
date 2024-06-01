namespace ECommerceAPI.Data.Models
{
    public class Brand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
