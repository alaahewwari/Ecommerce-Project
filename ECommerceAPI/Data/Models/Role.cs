using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Data.Models
{
    public class Role : IdentityRole<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
