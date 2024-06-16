using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AthenaEDU.Models
{
    public class Category

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Category() { }
        public Category(string name) 
        {
            Name = name;
        }
    }
}
