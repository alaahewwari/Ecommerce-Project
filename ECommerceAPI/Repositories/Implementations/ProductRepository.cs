using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;

namespace ECommerceAPI.Repositories.Implementations
{
    public class ProductRepository(
        ApplicationDbContext context 
        )
        : IProductRepository
    {
        public async Task<Product> CreateProductAsync(Product product)
        {
            product.CreatedDate = DateTime.Now;
            var result= await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
