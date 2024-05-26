using ECommerceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                               c =>
                               {
                    c.SwaggerDoc("v1", new() { Title = "ECommerceAPI", Version = "v1" });
                });
            services.ConfigureBuisnessServices();

        }
    }
}
