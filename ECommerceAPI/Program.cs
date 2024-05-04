using ECommerceAPI.Configurations;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapperServices();

builder.Services.AddServices(configuration);
var app = builder.Build();

app.UseMiddleware();

app.MapCategoryEndpoints();
app.MapBrandEndpoints();
app.MapProductEndpoints();

app.Run();
