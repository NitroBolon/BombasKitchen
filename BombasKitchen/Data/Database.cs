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
            _database.CreateTableAsync<RecipeProducts>();
        }

        public void ClearTables()
        {
            _database.DeleteAllAsync<Product>();
            _database.DeleteAllAsync<Recipe>();
            _database.DeleteAllAsync<Day>();
            _database.DeleteAllAsync<RecipeProducts>();
        }

        #region Products
        public Task<List<Product>> GetProducts()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public async Task<int> AddProduct(Product product)
        {
            await _database.InsertAsync(product);

            return _database.Table<Product>().ToListAsync().Result.Last().Id;
        }

        public Task<int> RemoveProduct(Product product)
        {
            _database.Table<RecipeProducts>().DeleteAsync(i => i.ProductId == product.Id);
            return _database.DeleteAsync(product);
        }

        public Task<int> UpdateProduct(Product product)
        {
            return _database.UpdateAsync(product);
        }
        #endregion

        #region Recipes
        public Task<List<Recipe>> GetRecipes()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public async Task<int> AddRecipe(Recipe recipe, List<Tuple<int, int>> products)
        {
            await _database.InsertAsync(recipe);
            var id = _database.Table<Recipe>().ToListAsync().Result.Last().Id;

            foreach (var product in products)
            {
                var recipeProduct = new RecipeProducts
                {
                    RecipeId = recipe.Id,
                    ProductId = product.Item1,
                    Amount = product.Item2
                };

                await _database.InsertAsync(recipeProduct);
            }

            return id;
        }

        public Task<int> RemoveRecipe(Recipe recipe)
        {
            _database.Table<RecipeProducts>().DeleteAsync(i => i.RecipeId == recipe.Id);
            return _database.DeleteAsync(recipe);
        }

        public Task<int> UpdateRecipe(Recipe recipe)
        {
            return _database.UpdateAsync(recipe);
        }
        #endregion

        #region RecipeProducts
        public Task<List<RecipeProducts>> GetRecipeProducts()
        {
            return _database.Table<RecipeProducts>().ToListAsync();
        }

        public async Task<int> AddRecipeProduct(Recipe recipe, List<Tuple<int, int>> products)
        {
            await _database.InsertAsync(recipe);
            var id = _database.Table<Recipe>().ToListAsync().Result.Last().Id;

            foreach (var product in products)
            {
                var recipeProduct = new RecipeProducts
                {
                    RecipeId = recipe.Id,
                    ProductId = product.Item1,
                    Amount = product.Item2
                };

                await _database.InsertAsync(recipeProduct);
            }

            return id;
        }

        public Task<int> RemoveRecipeProduct(Recipe recipe)
        {
            _database.Table<RecipeProducts>().DeleteAsync(i => i.RecipeId == recipe.Id);
            return _database.DeleteAsync(recipe);
        }

        public async Task<int> UpdateRecipeProduct(Recipe recipe, List<Joiner> products)
        {
            await _database.Table<RecipeProducts>().DeleteAsync(_ => _.RecipeId == recipe.Id);

            foreach (var product in products)
            {
                var recipeProduct = new RecipeProducts
                {
                    RecipeId = recipe.Id,
                    ProductId = product.product.Id,
                    Amount = product.amount
                };

                await _database.InsertAsync(recipeProduct);
            }

            return await _database.UpdateAsync(recipe);
        }
        #endregion
    }
}
