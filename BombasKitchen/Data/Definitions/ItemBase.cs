namespace BombasKitchen.Data.Definitions
{
    public class ItemBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ItemBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
