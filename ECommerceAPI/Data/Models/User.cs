using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
namespace ECommerceAPI.Data.Models
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public long? RoleId { get; set; }
        public Role? Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Product> CreatedProducts { get; set; } = new List<Product>();
        public ICollection<Product> UpdatedProducts { get; set; } = new List<Product>();
    }
}
