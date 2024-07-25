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
        Task<AttributeValue?> GetAttributeValueByIdAsync(long valueId);
        Task<bool> AddAttributeToProductAsync(ProductAttributeValue productAttributeValue);
        Task<IList<ProductAttributeValue>> GetProductAttributesAsync(long productId);
        Task<bool> UpdateProductAttributeAsync(ProductAttributeValue productAttributeValue);
        Task<bool> DeleteProductAttributeAsync(long productId, long attributeValueId);
    }
}