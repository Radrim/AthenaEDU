using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Test
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public bool IsPassed { get; set; } = false;
        public List<Question> Questions { get; set; }
        public Test() { }
        public Test(string name, string result, List<Question> questions)
        {
            Name = name;
            Result = result;
            Questions = questions;
        }
    }
}
