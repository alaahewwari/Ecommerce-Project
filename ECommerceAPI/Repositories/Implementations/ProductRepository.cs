using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories.Implementations
{
    public class ProductRepository(
        ApplicationDbContext context 
        )
        : IProductRepository
    {
        public async Task<Product?> CreateProductAsync(Product product)
        {
await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> GetProductByIdAsync(long productId)
        {
            var product = await context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
            return product;
        }
        public async Task<Product?> UpdateProductAsync(Product updatedProduct)
        {
            var product = await GetProductByIdAsync(updatedProduct.Id);
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.SalePrice = updatedProduct.SalePrice;
            product.BrandId = updatedProduct.BrandId;
            product.CategoryId = updatedProduct.CategoryId;
            product.Description = updatedProduct.Description;
            product.UpdatedDate = DateTime.Now;
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return product;
        }
        public async Task<IList<Product>> GetProductsAsync()
        {
            var products = await context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
            return products;
        }
        public async Task<bool> DeleteProductAsync(long productId)
        {
            var product = await GetProductByIdAsync(productId);
            if (product is null)
            {
                return false;
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
