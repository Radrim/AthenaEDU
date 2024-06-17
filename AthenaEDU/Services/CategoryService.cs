using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class CategoryService
    {
        private IMongoCollection<Category> _categories;
        

        public CategoryService(MongoDBConnection connection)
        {
            _categories = connection.database.GetCollection<Category>("Categories");
        }

        public async Task AddCategoryAsync(Category categories)
        {
            await _categories.InsertOneAsync(categories);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categories.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task DeleteCategoryByName(string title)
        {
            await _categories.DeleteOneAsync(x => x.Name == title);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categories.ReplaceOneAsync(x => x.Id == category.Id, category);
        }
    }
}
