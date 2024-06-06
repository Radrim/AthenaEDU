using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class ModuleService
    {
        private IMongoCollection<Course> _courses;

        public ModuleService(MongoDBConnection connection)
        {
            _courses = connection.database.GetCollection<Course>("Courses");
        }

        public async Task UpdateCourseModulesAsync(Course course, Module module)
        {
            await _courses.ReplaceOneAsync(x => x.Id == course.Id && course.Modules.Any(m => m.Id == module.Id), course);
        }

        public Course GetCourseByName(string name)
        {
            return _courses.Find(x => x.Name == name).FirstOrDefault();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _courses.ReplaceOneAsync(x => x.Id == course.Id, course);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}

