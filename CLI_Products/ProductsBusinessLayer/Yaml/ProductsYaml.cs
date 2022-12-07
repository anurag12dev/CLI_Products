using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Products.ProductsBusinessLayer.Yaml
{
    public class ProductsYaml
    {
        List<ProductDetailsYaml> productDetails { get; set; }
    }
    public class ProductDetailsYaml
    {
        public string? Tags { get; set; }
        public string? Twitter { get; set; }
        public string? Name { get; set; }
    }
}
