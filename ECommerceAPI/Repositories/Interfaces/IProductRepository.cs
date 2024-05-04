using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
    }
}
