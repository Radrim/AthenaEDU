using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class CourseService
    {
        private IMongoCollection<Course> _courses;

        public CourseService(MongoDBConnection connection)
        {
            _courses = connection.database.GetCollection<Course>("Courses");
        }

        public async Task AddUserAsync(Course course)
        {
            await _courses.InsertOneAsync(course);
        }

        public Course GetCourseByName(string name)
        {
            return _courses.Find(x => x.Name == name).FirstOrDefault();
        }

        public async Task UpdateUserAsync(string id, Course course)
        {
            await _courses.ReplaceOneAsync(x => x.Id == course.Id, course);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}
