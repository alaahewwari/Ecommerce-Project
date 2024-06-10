using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

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
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "Please enter into field the JWT Bearer",
                    In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new string[] { }
                        }
                    });
                });
        }
    }
}
