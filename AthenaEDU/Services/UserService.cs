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

        public async Task UpdateUserAsync(string id, User user)
        {
            await _users.ReplaceOneAsync(x => x.Id == user.Id, user);
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
