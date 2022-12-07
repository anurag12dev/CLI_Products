using CLI_Products.ProductsBusinessLayer;
using CLI_Products.SaasProducts;
using CLI_Products.SaasProducts.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace TestProjectProducts
{
    public class JsonProductsBLTest
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;
        private JsonProductsBL jsonProduct;
        private readonly IConfiguration _configuration;
        public JsonProductsBLTest()
        {
            // configure base services in memory
            _services = TestBase.ConfigureServices();
            _services.AddTransient<JsonProductsBL>();
            _serviceProvider = _services.BuildServiceProvider();
            _configuration = _serviceProvider.GetService<IConfiguration>() ?? throw new Exception("service not found");
        }

        [SetUp]
        public void Setup()
        {   // Installed Moq nuget package and utilizing for mocking reposotory methods.
            // Mock repository
            var mockRepository = new Mock<IFeedProductsRepository>();

            // Mock implementation of AddProducts method in Repository
            mockRepository.Setup(x => x.AddProducts(It.IsAny<List<ProductsDto>>())).Returns((List<ProductsDto> x)=>x.Count);

            // Complete the setup of our Mock Product Repository
            jsonProduct = new JsonProductsBL(_configuration,mockRepository.Object);
            
        }

        [Test]
        public void ProcessProducts_Pass()
        {
            string path = @"feed-products\softwareadvice.json"; // valid path
            var res = jsonProduct.ProcessProducts(path);
            Assert.That(res, Is.True) ;
        }
        [Test]
        public void ProcessProducts_Fail()
        {
            string path = @"products\softwareadvice.json"; // setting invalid path
            var res = jsonProduct.ProcessProducts(path);
            Assert.That(res, Is.EqualTo(false));
        }
    }


}