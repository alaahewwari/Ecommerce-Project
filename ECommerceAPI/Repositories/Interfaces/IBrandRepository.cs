using ECommerceAPI.Data.Models;

namespace ECommerceAPI.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand?> GetBrandByIdAsync(long brandId);
    }
}
