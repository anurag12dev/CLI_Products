using CLI_Products.ProductsBusinessLayer;
using CLI_Products.SaasProducts;

namespace CLI_Products
{
    public class ProductFactory
    {
        private readonly IEnumerable<IElementCreator> _elmentCreators;
        public ProductFactory(IEnumerable<IElementCreator> treeElementCreators)
        {
            _elmentCreators = treeElementCreators;
        }      
                
        public IProductBL GetProductObject(string productType)
        {
            return _elmentCreators.SingleOrDefault(x => x.Type == productType)?.CreateElement() ?? throw new ArgumentException($"Invalid argument {productType}. Please verify input.");
            
        }

    }


}
