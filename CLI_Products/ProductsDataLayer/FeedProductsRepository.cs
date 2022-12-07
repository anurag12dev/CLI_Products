using CLI_Products.SaasProducts.DTO;
using Microsoft.Extensions.Configuration;

namespace CLI_Products.SaasProducts
{
    public class FeedProductsRepository: IFeedProductsRepository
    {
        //public IConfiguration Configuration { get; }

        private IConfiguration _Configuration;
        private string? connectionString = null;
        public FeedProductsRepository(IConfiguration Configuration) {
            _Configuration = Configuration;
        }  
        public int AddProducts(List<ProductsDto> l) 
        {

            connectionString = _Configuration["Settings:DBConnectionString"];

            // logic to add the products into database MYSQL

            return l.Count;
        }
    }
}
