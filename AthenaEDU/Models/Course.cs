using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
        public bool isPrivate { get; set; }
        public List<Module> Modules { get; set; } = new List<Module>();
        public List<CourseCategory> Categories { get; set; } = new List<CourseCategory>();

        public Course() { }

        public Course(string name, string description, string imageName) 
        {
            Name = name;
            Description = description;
            ImageName = imageName;
        }
       
    }
}
