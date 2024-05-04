using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories.Implementations
{
    public class BrandRepository(
        ApplicationDbContext context
        )
        : IBrandRepository
    {
       
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await context.Brands.ToListAsync();
        }
        public async Task<Brand?> GetBrandByIdAsync(long brandId)
        {
            var brand = await context.Brands
                 .Where(b => b.Id == brandId)
                 .FirstOrDefaultAsync();
           return brand;
        }
    }
}
