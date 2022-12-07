using CLI_Products.ProductsBusinessLayer;
using CLI_Products.SaasProducts.DTO;
using CLI_Products.SaasProducts;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace TestProjectProducts
{
    public class YamlProductsBLTest
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private YamlProductsBL _yamlProductBL;
        private readonly IConfiguration _configuration;
        public YamlProductsBLTest()
        {
            // configure base services in memory
            _services = TestBase.ConfigureServices();
            _services.AddTransient<YamlProductsBL>();
            _serviceProvider = _services.BuildServiceProvider();
            _configuration = _serviceProvider.GetService<IConfiguration>() ?? throw new Exception("service not found");
        }


        [SetUp]
        public void Setup()
        {
            // Installed Moq nuget package and utilizing for mocking reposotory methods.
            // Mock repository
            var mockRepository = new Mock<IFeedProductsRepository>();

            // Mock implementation of AddProducts method in Repository
            mockRepository.Setup(x => x.AddProducts(It.IsAny<List<ProductsDto>>())).Returns((List<ProductsDto> x) => x.Count);

            // Complete the setup of our Mock Product Repository
            _yamlProductBL = new YamlProductsBL(_configuration, mockRepository.Object);
        }

        [Test]
        public void ProcessProducts_Pass()
        {
            string path = @"feed-products\capterra.yaml"; // valid path
            var res = _yamlProductBL.ProcessProducts(path);
            Assert.IsTrue(res);
        }
        [Test]
        public void ProcessProducts_Fail()
        {
            string path = @"products\capterra.yaml"; // setting invalid path
            var res = _yamlProductBL.ProcessProducts(path);
            Assert.That(res, Is.EqualTo(false));
        }
    }
}