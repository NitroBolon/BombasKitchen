using BombasKitchen.Data.Definitions;
using BombasKitchen.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace BombasKitchen.Data.Middleware
{
    public class ProductsProcessor
    {
        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();

            
            return result;
        }

        public Product GetProductById(string id)
        {


            return new Product();
        }

        public void AddNewProduct(Product product)
        {
            
        }
    }
}
