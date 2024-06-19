using AthenaEDU.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class UserService
    {
        public User CurrentUser { get; set; }
        private IMongoCollection<User> _users;

        public UserService(MongoDBConnection connection)
        {
            _users = connection.database.GetCollection<User>("Users");
        }

        public async Task AddUserAsync(User user) 
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<List<User>> GetJoinedUsersByCourseId(string courseId) 
        {
            var filter = Builders<User>.Filter.AnyEq(u => u.ActiveCourses, courseId);
            var users = await _users.Find(filter).ToListAsync();
            return users;
        }

        public bool IsStudentInCourse(User student, string courseId)
        {
            // Предполагаем, что у вас есть доступ к базе данных или к списку студентов
            var user = _users.Find(u => u.Id == student.Id).FirstOrDefault();
            return user != null && user.ActiveCourses.Contains(courseId);
        }

        public User GetUserByEmail(string email)
        {
            return _users.Find(x => x.Email == email).FirstOrDefault();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }

        public bool IsActive(string courseId) 
        {
            return CurrentUser.ActiveCourses.Contains(courseId);
        }

        public async Task DeleteCourseAsync(string Id) 
        {
            var userFilter = Builders<User>.Filter.AnyEq(u => u.MyCourses, Id);
            var update = Builders<User>.Update.Pull(u => u.MyCourses, Id);
            await _users.UpdateManyAsync(userFilter, update);
        }

        public void AuthorizeUser(string email, string password)
        {
            CurrentUser = _users.Find(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public void Logout() 
        {
            CurrentUser = null;
        }
    }
}
