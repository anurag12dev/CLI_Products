using CLI_Products.ProductsBusinessLayer.Json;
using CLI_Products.SaasProducts;
using CLI_Products.SaasProducts.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CLI_Products.ProductsBusinessLayer
{
    public class JsonProductsBL : IProductBL
    {
        readonly IFeedProductsRepository _feedProductsDAL;
        readonly IConfiguration _configuration;
        private List<ProductsDto> productsDto = new();

        public JsonProductsBL(IConfiguration configuration,IFeedProductsRepository feedProductsDAL) {
            _feedProductsDAL = feedProductsDAL;
            _configuration = configuration;
        }

        #region ProcessProducts
        /// <summary>
        /// Logic for reading the json file and call DAL(data access layer) to save data.
        /// </summary>
        /// <param name="path"></param>
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

                List<ProductDetails> products = new();
                using (StreamReader reader = new(filePath))
                {
                    string jsonString = reader.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<Products>(jsonString);
                    products = data.products;
                }
                //helper menthod to convert or map the object to DTO type which can be accepted by DAL
                Helper.MapJsonToDto(products, out productsDto);
                foreach (var product in productsDto)
                {
                    Console.WriteLine($"Importing: Name: {product.Name}; Categories: {product.Categories}; Twitter: {product.Twitter}");

                }

                bool result = AddProducts(productsDto);
                if (result)
                {
                    Console.WriteLine("Products added into database.");
                }
                else
                {
                    Console.WriteLine("Products could not be added into database.");
                }
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region SaveProducts
        /// <summary>
        /// call DAL to save products to database
        /// </summary>
        /// <param name="list"></param>
        /// <returns>bool</returns>
        private bool AddProducts(List<ProductsDto> list)
        {
            int res = _feedProductsDAL.AddProducts(list);

            return res > 0;
        }
        #endregion
    }
}
