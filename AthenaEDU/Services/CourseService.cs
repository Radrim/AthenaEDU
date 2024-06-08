using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AthenaEDU.Services
{
    public class CourseService
    {
        private IMongoCollection<Course> _courses;

        public CourseService(MongoDBConnection connection)
        {
            _courses = connection.database.GetCollection<Course>("Courses");
        }

        public async Task AddCourseAsync(Course course)
        {
            await _courses.InsertOneAsync(course);
        }

        public Course GetCourseByName(string name)
        {
            return _courses.Find(x => x.Name == name).FirstOrDefault();
        }

        public Course GetCourseById(string id)
        {
            return _courses.Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _courses.ReplaceOneAsync(x => x.Id == course.Id, course);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public void ReplaceModuleAsync(Course course, Module module) 
        {
            int index = course.Modules.FindIndex(x => x.Id == module.Id);

            if (index  != -1) 
            {
                course.Modules[index] = module;
                _courses.ReplaceOne(x => x.Id == course.Id, course);
            }
        }

        public async Task<List<Course>> FindBySearchCourses(string searchText)
        {
            var allCourses = await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();

            // Выполнение поиска асинхронно, используя Task.Run для синхронной операции
            var filteredCourses = await Task.Run(() =>
            {
                return allCourses.Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            });

            return filteredCourses;
        }

        public async Task<List<Course>> FindByCategoryCourses(string categoryName)
        {
            var allCourses = await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();

            // Выполнение поиска асинхронно, используя Task.Run для синхронной операции
            var filteredCourses = await Task.Run(() =>
            {
                return allCourses.Where(x => x.Category.Name == categoryName).ToList();
            });

            return filteredCourses;
        }

        public async Task<List<Course>> FindByCategoryAndSearchCourses(string categoryName, string searchText)
        {
            var allCourses = await _courses.FindAsync(new BsonDocument()).Result.ToListAsync();

            // Выполнение поиска асинхронно, используя Task.Run для синхронной операции
            var filteredCourses = await Task.Run(() =>
            {
                return allCourses.Where(x => x.Category.Name == categoryName && x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            });

            return filteredCourses;
        }
    }
}
