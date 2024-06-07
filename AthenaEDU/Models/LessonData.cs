using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class LessonData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string FileName { get; set; }
        public byte[] FileContent {  get; set; }
    }
}
