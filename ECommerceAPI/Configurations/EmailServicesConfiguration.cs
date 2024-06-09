using ECommerceAPI.Infrastructure.Configurations;
namespace ECommerceAPI.Configurations
{
    public static class EmailServiceExtensions
    {
        public static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig!);

            services.Configure<EmailConfiguration>(configuration.GetSection("EmailConfiguration"));
        }
    }
}
