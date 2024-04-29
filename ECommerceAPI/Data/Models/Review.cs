using System.Numerics;

namespace ECommerceAPI.Data.Models
{
    public class Review
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate{ get; set; }
        public long ProductId { get; set; }
        public long CustomerId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
