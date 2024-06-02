using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product updatedProduct);
        Task<Product?> GetProductByIdAsync(long productId);
        Task<IList<Product>> GetProductsAsync();
        Task<bool> DeleteProductAsync(long productId);
    }
}
