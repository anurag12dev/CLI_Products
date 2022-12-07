using CLI_Products.ProductsBusinessLayer;

namespace CLI_Products
{
    public interface IElementCreator
    {
        string Type { get; }
        IProductBL CreateElement();
    }

    public class JsonCreator : IElementCreator
    {
        private IProductBL _jsonProduct;
        public JsonCreator(JsonProductsBL jsonProduct)
        {
            _jsonProduct = jsonProduct;
        }
        public string Type => "softwareadvice";

        public IProductBL CreateElement()
        {
            return _jsonProduct;
        }
    }

    public class YamlCreator : IElementCreator
    {
        private IProductBL _yamlProduct;
        public YamlCreator(YamlProductsBL yamlProduct)
        {
            _yamlProduct = yamlProduct;
        }
        public string Type => "capterra";

        public IProductBL CreateElement()
        {
            return _yamlProduct;
        }
    }
}
