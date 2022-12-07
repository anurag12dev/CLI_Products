using CLI_Products.SaasProducts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Products.SaasProducts
{
    public interface IFeedProductsRepository
    {
        int AddProducts(List<ProductsDto> l);
    }
}
