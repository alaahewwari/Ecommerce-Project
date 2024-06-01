namespace ECommerceAPI.Data.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
