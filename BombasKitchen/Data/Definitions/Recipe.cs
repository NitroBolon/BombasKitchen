namespace BombasKitchen.Data.Definitions
{
    public class Recipe : ItemBase
    {
        public List<Product> Products { get; set; }
        public string Description { get; set; }

        public Recipe()
        {
            Products = new List<Product>();
        }
    }
}
