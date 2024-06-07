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
        public string Author { get; set; }
        public bool isPrivate { get; set; }
        public bool isPublished { get; set; } = false;
        public List<Module> Modules { get; set; } = new List<Module>();
        public CourseCategory Category { get; set; }

        public Course() { }
    }
}
