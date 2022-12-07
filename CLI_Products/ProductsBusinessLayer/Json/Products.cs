using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Products.ProductsBusinessLayer.Json
{
    public class Products
    {
        public List<ProductDetails> products { get; set; }
    }

    public class ProductDetails
    {
        public string[]? Categories { get; set; }
        public string? Twitter { get; set; }
        public string? Title { get; set; }
    }
}
