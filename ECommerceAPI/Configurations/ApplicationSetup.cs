namespace ECommerceAPI.Configurations
{
    public static class ApplicationSetup
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddIdentity();
            services.AddSwagger();
            services.AddAutoMapper();
            services.AddAuthentication(configuration);
            services.ConfigureBusinessServices();
            services.AddEmailServices(configuration);
        }
    }
}
