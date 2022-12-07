namespace CLI_Products
{
    public class StartUp
    {
        private readonly ProductFactory _productFactory;
        public StartUp(ProductFactory product)
        {
            _productFactory = product;
        }
        /// <summary>
        /// Application needs 2 arguments to work i.e. type and file path
        /// Example 1: softwareadvice feed-products\softwareadvice.json
        /// Example 2: capterra feed-products\capterra.yaml
        /// </summary>
        /// <param name="args"></param>
        public void Run(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    Helper.ShowValidationMessage();
                    return;
                }

                try
                {
                    var obj = _productFactory.GetProductObject(args[0]);
                    if (obj != null)
                        obj.ProcessProducts(args[1]);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
