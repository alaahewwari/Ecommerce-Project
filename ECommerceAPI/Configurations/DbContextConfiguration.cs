using ECommerceAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace ECommerceAPI.Configurations
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

        }
    }
}
