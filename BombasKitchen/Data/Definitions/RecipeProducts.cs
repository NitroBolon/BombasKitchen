using SQLite;

namespace BombasKitchen.Data.Definitions
{
    public class RecipeProducts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; } 
    }
}
