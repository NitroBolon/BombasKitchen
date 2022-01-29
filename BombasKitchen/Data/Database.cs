using BombasKitchen.Data.Definitions;
using SQLite;

namespace BombasKitchen.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(String dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>();
            _database.CreateTableAsync<Recipe>();
            _database.CreateTableAsync<Day>();
        }

        public void ClearTableProduct()
        {
            _database.DeleteAllAsync<Product>();
        }

        public Task<List<Product>> GetProducts()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public int IdOfNewestProduct()
        {
            return _database.Table<Product>().ToListAsync().Result.Last().Id;
        }

        public async Task<int> AddProduct(Product product)
        {
            await _database.InsertAsync(product);

            return _database.Table<Product>().ToListAsync().Result.Last().Id;
        }

        public Task<int> RemoveProduct(Product product)
        {
            return _database.DeleteAsync(product);
        }

        public Task<int> UpdateProduct(Product product)
        {
            return _database.UpdateAsync(product);
        }
    }
}
