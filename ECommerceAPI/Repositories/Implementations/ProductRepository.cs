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
                .Include(p => p.CreatedUser)
                .Include(p => p.UpdatedUser)
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
                .Include(p => p.CreatedUser)
                .Include(p => p.UpdatedUser)
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
        public async Task<AttributeValue?> GetAttributeValueByIdAsync(long valueId)
        {
            var value = await context.AttributeValues
                .AsNoTracking()
                .Where(v => v.Id == valueId)
                .FirstOrDefaultAsync();
            return value;
        }
        public async Task<bool> AddAttributeToProductAsync(ProductAttributeValue attributeValue)
        {
            context.ProductAttributeValues.Add(attributeValue);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IList<ProductAttributeValue>> GetProductAttributesAsync(long productId)
        {
            var attributes = await context.ProductAttributeValues
                .Include(pav => pav.Product)
                .Include(pav => pav.AttributeValue)
                .AsNoTracking()
                .Where(pav => pav.ProductId == productId)
                .ToListAsync();
            return attributes;
        }
        public async Task<bool> UpdateProductAttributeAsync(ProductAttributeValue productAttributeValue)
        {
            var attribute = await context.ProductAttributeValues
                .Where(pav => pav.ProductId == productAttributeValue.ProductId)
                .Where(pav => pav.AttributeValueId == productAttributeValue.AttributeValueId)
                .FirstOrDefaultAsync();
            if (attribute is null)
            {
                return false;
            }
            attribute.Quantity = productAttributeValue.Quantity;
            context.ProductAttributeValues.Update(attribute);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductAttributeAsync(long productId, long attributeValueId)
        {
            var attribute = await context.ProductAttributeValues
                .Where(pav => pav.ProductId == productId)
                .Where(pav => pav.AttributeValueId == attributeValueId)
                .FirstOrDefaultAsync();
            if (attribute is null)
            {
                return false;
            }
            context.ProductAttributeValues.Remove(attribute);
            await context.SaveChangesAsync();
            return true;
        }
    }
}