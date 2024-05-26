using MongoDB.Driver;

namespace AthenaEDU.Services
{
    public class MongoDBConnection
    {
        public IMongoDatabase database;
        string _defaultConnectionString = "mongodb://localhost";

        public MongoDBConnection()
        {
            var client = new MongoClient(_defaultConnectionString);
            database = client.GetDatabase("AthenaEDU_DB");
        }
    }
}
