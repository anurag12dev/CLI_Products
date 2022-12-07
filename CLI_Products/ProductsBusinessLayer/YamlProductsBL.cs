using CLI_Products.ProductsBusinessLayer.Yaml;
using CLI_Products.SaasProducts;
using CLI_Products.SaasProducts.DTO;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace CLI_Products.ProductsBusinessLayer
{

    public class YamlProductsBL : IProductBL
    {
        readonly IConfiguration _configuration;
        readonly IFeedProductsRepository _feedProductsDAL;
        public YamlProductsBL(IConfiguration configuration, IFeedProductsRepository feedProductsDAL)
        {
            _feedProductsDAL = feedProductsDAL;
            _configuration = configuration;
        }

        private List<ProductsDto> productsDto = new();

        #region ProcessProducts
        /// <summary>
        /// Logic to read Yaml file and call DAL(data access layer) to save data into database.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ProcessProducts(string path)
        {
            try
            {
                string? baseDrvie = _configuration["Settings:ProductsDriveLocation"] ?? @"C:\";
                var filePath = Path.Combine(baseDrvie, path);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Invalid file path: {filePath}");
                    Helper.ShowInvalidPathMessage();
                    return false;
                }

                List<ProductDetailsYaml> products = new();
                using (StreamReader reader = new(filePath))
                {
                    string ymlContents = reader.ReadToEnd();
                    var deserializer = new DeserializerBuilder()
                                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                        .Build();
                    products = deserializer.Deserialize<List<ProductDetailsYaml>>(ymlContents);
                }

                Helper.MapYamlToDto(products, out productsDto);
                foreach (var product in productsDto)
                {
                    Console.WriteLine($"Importing: Name: {product.Name}; Categories: {product.Categories}; Twitter: {product.Twitter}");

                }
                bool result = SaveProducts(productsDto);
                if (result)
                {
                    Console.WriteLine("Products saved into database.");
                }
                else
                {
                    Console.WriteLine("Products could not be saved into database.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        #endregion

        #region SaveProducts
        /// <summary>
        /// Call DAL to save products into database
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveProducts(List<ProductsDto> list)
        {
            int res = _feedProductsDAL.AddProducts(list);

            return res > 0;
        }
        #endregion


    }
}
