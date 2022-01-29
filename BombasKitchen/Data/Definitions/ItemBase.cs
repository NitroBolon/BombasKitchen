using SQLite;
using System.ComponentModel;

namespace BombasKitchen.Data.Definitions
{
    public class ItemBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
