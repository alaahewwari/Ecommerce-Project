namespace ECommerceAPI.Data.Models
{
    public class CategoryAttribute
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> categories { get; set; } = new List<Category>();
    }
}
