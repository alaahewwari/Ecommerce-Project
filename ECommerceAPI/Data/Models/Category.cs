using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ECommerceAPI.Data.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; } = new List<CategoryAttribute>();
    }
}
