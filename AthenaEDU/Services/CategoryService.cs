using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class CategoryService
    {
        private IMongoCollection<CourseCategory> _categories;

        public CategoryService(MongoDBConnection connection)
        {
            _categories = connection.database.GetCollection<CourseCategory>("Categories");
        }

        public async Task AddCategoryAsync(CourseCategory categories)
        {
            await _categories.InsertOneAsync(categories);
        }

        public async Task<List<CourseCategory>> GetAllCategories()
        {
            return await _categories.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task DeleteCategoryByName(string title)
        {
            await _categories.DeleteOneAsync(x => x.Name == title);
        }
    }
}
