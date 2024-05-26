using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Module
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public List<Lesson> Lessons { get; private set; } = new List<Lesson>();

        public Module(string name, List<Lesson> lessons)
        {
            Name = name;
            Lessons = lessons;
        }
    }
}
