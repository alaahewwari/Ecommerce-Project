using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> CreateBrandAsync(Brand brand);
        Task<Brand?> UpdateBrandAsync(Brand updatedBrand, long brandId);
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand?> GetBrandByIdAsync(long brandId);
        Task<Brand?> GetBrandByNameAsync(string name);
        Task<bool> DeleteBrandAsync(long brandId);
    }
}
