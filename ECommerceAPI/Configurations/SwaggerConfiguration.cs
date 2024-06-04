namespace ECommerceAPI.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new() { Title = "ECommerceAPI", Version = "v1" });
                });
        }
    }
}
