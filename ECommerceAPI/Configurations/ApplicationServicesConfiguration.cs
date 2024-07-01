using ECommerceAPI.Repositories.Implementations;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.AuthenticationServices.Implementations;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using ECommerceAPI.Services.BrandServices.Implementations;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.CartServices.Implementations;
using ECommerceAPI.Services.CartServices.Interfaces;
using ECommerceAPI.Services.CategoryServices.Implementations;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ECommerceAPI.Services.CustomerServices.Implementations;
using ECommerceAPI.Services.CustomerServices.Interfaces;
using ECommerceAPI.Services.EmailServices.Implementations;
using ECommerceAPI.Services.EmailServices.Interfaces;
using ECommerceAPI.Services.IdentityServices.Implementations;
using ECommerceAPI.Services.IdentityServices.Interfaces;
using ECommerceAPI.Services.OrderServices.Implementations;
using ECommerceAPI.Services.OrderServices.Interfaces;
using ECommerceAPI.Services.PaymentServices.Implementations;
using ECommerceAPI.Services.PaymentServices.Interfaces;
using ECommerceAPI.Services.ProductServices.Implementations;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ECommerceAPI.Services.ReviewServices.Implementations;
using ECommerceAPI.Services.ReviewServices.Interfaces;
using ECommerceAPI.Services.RoleServices.Implementations;
using ECommerceAPI.Services.RoleServices.Interfaces;
using ECommerceAPI.Services.TokenService.Implementations;
using ECommerceAPI.Services.TokenService.Interfaces;
using ECommerceAPI.Services.UrlBuilder.Implementations;
using ECommerceAPI.Services.UrlBuilder.Interfaces;
using ECommerceAPI.Services.UserServices.Implementations;
using ECommerceAPI.Services.UserServices.Interfaces;
namespace ECommerceAPI.Configurations
{
    public static class ApplicationServicesConfiguration
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<IUrlBuilder, UrlBuilder>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}