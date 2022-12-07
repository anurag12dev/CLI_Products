using CLI_Products.ProductsBusinessLayer.Json;
using CLI_Products.ProductsBusinessLayer.Yaml;
using CLI_Products.SaasProducts.DTO;

namespace CLI_Products
{
    public class Helper
    {
        /// <summary>
        /// To map Json object to ProductsDto type
        /// </summary>
        /// <param name="data"></param>
        /// <param name="list"></param>
        public static void MapJsonToDto(List<ProductDetails> data,out List<ProductsDto> list)
        {
            list = new List<ProductsDto>();

            
                foreach (var item in data)
                {
                    list.Add(new ProductsDto { Name = item.Title, Twitter = item.Twitter, Categories = string.Join(',', item.Categories) });
                }
            
        }

        /// <summary>
        /// To map yaml object to ProductsDto type
        /// </summary>
        /// <param name="data"></param>
        /// <param name="list"></param>
        public static void MapYamlToDto(List<ProductDetailsYaml> data, out List<ProductsDto> list)
        {
            list = new List<ProductsDto>();


            foreach (var item in data)
            {
                list.Add(new ProductsDto { Name = item.Name, Twitter = item.Twitter, Categories = item.Tags});
            }

        }

        /// <summary>
        /// Show message when user enters invalid command in console
        /// </summary>
        public static void ShowValidationMessage()
        {
            Console.WriteLine("Invalid command...");
            Console.WriteLine("You may enter the command like \"import softwareadvice feed-products\\softwareadvice.json\"");
            Console.WriteLine("or \"import capterra feed-products\\capterra.yaml\"");
        }

        /// <summary>
        /// Invalid path message
        /// </summary>
        public static void ShowInvalidPathMessage()
        {
            Console.WriteLine("You may enter the value for second argument i.e. file path like \"feed-products\\softwareadvice.json\"");
            Console.WriteLine("or \"feed-products\\capterra.yaml\"");
        }
    }
}
