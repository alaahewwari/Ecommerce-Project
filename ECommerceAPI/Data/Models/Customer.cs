using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ECommerceAPI.Data.Models
{
    public class Customer : User
    {
        public string PhoneNumber { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> reviews { get; set; } = new List<Review>();

    }
}
