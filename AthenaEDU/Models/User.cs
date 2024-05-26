using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ImageName { get; private set; }
        public string Role { get; private set; } = "Пользователь";
        public List<Course> ActiveCourses { get; private set; } = new List<Course>();

        public User(string name, string surname, string patronymic, string email, string password, string imageName)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Password = password;
            ImageName = imageName;
        }
    }
}
