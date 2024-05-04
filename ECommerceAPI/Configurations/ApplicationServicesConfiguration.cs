using ECommerceAPI.Repositories.Implementations;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Implementations;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.CategoryServices.Implementations;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ECommerceAPI.Services.ProductService.Implementations;
using ECommerceAPI.Services.ProductServices.Interfaces;

namespace ECommerceAPI.Configurations
{
    public static class ApplicationServicesConfiguration
    {
        public static void ConfigureBuisnessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();

        }
    }
}
