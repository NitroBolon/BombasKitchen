using BombasKitchen.Enums;
using System.ComponentModel;

namespace BombasKitchen.Data.Definitions
{
    public class Product : ItemBase
    {
        [DisplayName("Amount")]
        public int Amount { get; set; }
        [DisplayName("Unit")]
        public UnitTypes Unit { get; set; }
    }
}
