using BombasKitchen.Enums;

namespace BombasKitchen.Data.Definitions
{
    public class Product : ItemBase
    {
        public int Amount { get; set; }
        public UnitTypes Unit { get; set; }
    }
}
