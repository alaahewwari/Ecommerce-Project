﻿namespace ECommerceAPI.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
