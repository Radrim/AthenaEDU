using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Lesson
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Document LessonDocument { get; set; }
        public Test LessonTest { get; set; }
        public Lesson() { }
        public Lesson(string name, Document lessonDocument, Test lessonTest)
        {
            Name = name;
            LessonDocument = lessonDocument;
            LessonTest = lessonTest;
        }
    }
}
