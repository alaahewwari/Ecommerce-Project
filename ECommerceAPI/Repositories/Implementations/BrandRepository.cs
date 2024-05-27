using ECommerceAPI.Data;
using ECommerceAPI.Data.Models;
using ECommerceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories.Implementations
{
    public class BrandRepository(
        ApplicationDbContext context)
        : IBrandRepository
    {
        public async Task<Brand> CreateBrandAsync(Brand brand)
        {
            await context.Brands.AddAsync(brand); //should I return the added brand or the brand in parameter?
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand?> UpdateBrandAsync(Brand updatedBrand, long brandId)
        {
            var brand = await GetBrandByIdAsync(brandId);
            brand.Name = updatedBrand.Name;
            context.Brands.Update(brand); //Necessary to tell EF to track this brand and consider it modified
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            var brands = await context.Brands.AsNoTracking().ToListAsync();
            return brands;
        }

        public async Task<Brand?> GetBrandByIdAsync(long brandId)
        {
            var brand = await context.Brands
                .AsNoTracking()
                .Where(b => b.Id == brandId)
                .FirstOrDefaultAsync();
            return brand;
        }

        public async Task<Brand?> GetBrandByNameAsync(string brandName)
        {
            var brand = await context.Brands
                .Where(b => b.Name == brandName)
                .FirstOrDefaultAsync();
            return brand;
        }

        public async Task<bool> DeleteBrandAsync(long brandId)
        {
            var brand = await GetBrandByIdAsync(brandId);
            if (brand is null)
            {
                return false;
            }

            context.Brands.Remove(brand);
            await context.SaveChangesAsync();
            return true;
        }
    }
}