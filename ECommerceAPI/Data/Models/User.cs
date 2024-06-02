using Microsoft.AspNetCore.Identity;
namespace ECommerceAPI.Data.Models
{
    public class User : IdentityUser<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfileImageUrl { get; set; }
        public long? RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<Product> CreatedProducts { get; set; } = new List<Product>();
        public ICollection<Product> UpdatedProducts { get; set; } = new List<Product>();
    }
}
