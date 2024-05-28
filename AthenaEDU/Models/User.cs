using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageName { get; set; }
        public string Role { get; set; } = "User";
        public List<Course> ActiveCourses { get; set; } = new List<Course>();
        public List<Course> MyCourses { get; set; } = new List<Course>();

        public User() { }

        public User(string name, string surname, string patronymic, string email, string password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Password = password;
        }
    }
}
