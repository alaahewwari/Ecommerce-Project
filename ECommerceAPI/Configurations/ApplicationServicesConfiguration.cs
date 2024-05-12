using ECommerceAPI.Repositories.Implementations;
using ECommerceAPI.Repositories.Interfaces;
using ECommerceAPI.Services.BrandServices.Implementations;
using ECommerceAPI.Services.BrandServices.Interfaces;
using ECommerceAPI.Services.CartServices.Implementations;
using ECommerceAPI.Services.CartServices.Interfaces;
using ECommerceAPI.Services.CategoryServices.Implementations;
using ECommerceAPI.Services.CategoryServices.Interfaces;
using ECommerceAPI.Services.CustomerServices.Implementations;
using ECommerceAPI.Services.CustomerServices.Interfaces;
using ECommerceAPI.Services.OrderServices.Implementations;
using ECommerceAPI.Services.OrderServices.Interfaces;
using ECommerceAPI.Services.PaymentServices.Implementations;
using ECommerceAPI.Services.PaymentServices.Interfaces;
using ECommerceAPI.Services.ProductService.Implementations;
using ECommerceAPI.Services.ProductServices.Interfaces;
using ECommerceAPI.Services.ReviewServices.Implementations;
using ECommerceAPI.Services.ReviewServices.Interfaces;
using ECommerceAPI.Services.RoleServices.Implementations;
using ECommerceAPI.Services.RoleServices.Interfaces;
using ECommerceAPI.Services.UserServices.Implementations;
using ECommerceAPI.Services.UserServices.Interfaces;

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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
