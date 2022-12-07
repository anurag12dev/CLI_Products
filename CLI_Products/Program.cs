using CLI_Products.ProductsBusinessLayer;
using CLI_Products.SaasProducts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLI_Products;
class Program
{
    private static StartUp _startApplication;
    static void Main(string[] args)
    {
        IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();

        // Create service collection and configure our services
        var services = ConfigureServices().AddSingleton<IConfiguration>(Configuration);
        
        // Generate a provider
        var serviceProvider = services.BuildServiceProvider();

        // Kick off our actual code
        _startApplication = serviceProvider.GetService<StartUp>() ?? throw new Exception("StartUp service not found");
       
        if (_startApplication != null)
          _startApplication.Run(args);       

    }

    /// <summary>
    /// Register requied classes as services
    /// </summary>
    /// <returns>IServiceCollection</returns>
    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<ProductFactory>();
        services.AddTransient<JsonProductsBL>();
        services.AddTransient<YamlProductsBL>();
        services.AddTransient<IElementCreator, JsonCreator>();
        services.AddTransient<IElementCreator, YamlCreator>();
        services.AddTransient<IFeedProductsRepository, FeedProductsRepository>();
        services.AddTransient<StartUp>();
        return services;
    }
}