using CLI_Products;
using CLI_Products.ProductsBusinessLayer;
using CLI_Products.SaasProducts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestProjectProducts
{
    public class TestBase
    {
        public static IServiceCollection ConfigureServices()
        {
            IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

            // Create service collection and configure our services
            //var services = ConfigureServices()
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ProductFactory>();
            services.AddTransient<IFeedProductsRepository, FeedProductsRepository>();
            services.AddTransient<JsonProductsBL>();
            services.AddTransient<YamlProductsBL>();
            services.AddTransient<IElementCreator, JsonCreator>();
            services.AddTransient<IElementCreator, YamlCreator>();
            services.AddTransient<StartUp>();
            services.AddSingleton<IConfiguration>(Configuration);
            return services;
        }
    }
}
