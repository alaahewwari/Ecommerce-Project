using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ECommerceAPI.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public long? UpdatedUserId { get; set; }
        public long? CreatedUserId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public User? UpdatedUser { get; set; }
        public User? CreatedUser { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
