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
        public LessonData LessonFile { get; private set; }

        public Lesson() { }

        public Lesson(string name, LessonData lessonData)
        {
            Name = name;
            LessonFile = lessonData;
        }
    }
}
