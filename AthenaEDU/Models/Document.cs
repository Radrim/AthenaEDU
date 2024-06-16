using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent {  get; set; }
        public Document() { }
        public Document(string fileName, byte[] fileContent)
        { 
            FileName = fileName;
            FileContent = fileContent;
        }
    }
}
