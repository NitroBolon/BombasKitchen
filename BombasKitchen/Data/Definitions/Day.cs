namespace BombasKitchen.Data.Definitions
{
    public class Day : ItemBase
    {
        public List<Recipe> Recipes { get; set; }

        public Day()
        {
            Id = Guid.NewGuid().ToString();
            Recipes = new List<Recipe>();
        }
    }
}
