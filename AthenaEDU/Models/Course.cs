using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string? ImageName { get; private set; }
        public bool isPrivate { get; private set; }
        public List<Module> Modules { get; private set; } = new List<Module>();
        public List<CourseCategory> Categories { get; private set; } = new List<CourseCategory>();
       
    }
}
