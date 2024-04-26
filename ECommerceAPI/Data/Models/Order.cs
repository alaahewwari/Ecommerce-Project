using ECommerceAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ECommerceAPI.Data.Models
{
    public class Order
    {
        public long Id { get; set; }
        public int OrderNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public decimal totalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    }
}
