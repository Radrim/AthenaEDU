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

        public User GetUserByEmail(string email)
        {
            return _users.Find(x => x.Email == email).FirstOrDefault();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _users.ReplaceOneAsync(x => x.Id == user.Id, user);
        }

        public async Task<List<Course>> GetActiveCourses(string userId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
            var user = await _users.Find(filter).FirstOrDefaultAsync();
            return user?.ActiveCourses ?? new List<Course>();
        }

        public async Task<List<Course>> GetMyCourses(string userId)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
            var user = await _users.Find(filter).FirstOrDefaultAsync();
            return user?.MyCourses ?? new List<Course>();
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
