using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AthenaEDU.Services
{
    public class FileSystemService
    {
        private static MongoDBConnection _connection { get; set; }
        IGridFSBucket gridFS;
        public FileSystemService(MongoDBConnection connection)
        {
            _connection = connection;
            gridFS = connection.gridFS;
        }

        public async Task<ObjectId> UploadFileToDbAsync(string fileName, byte[] source) 
        {
            return await gridFS.UploadFromBytesAsync(fileName, source);
        }

        public async Task<byte[]> GetFileByNameAsync(string name) 
        {
            return await gridFS.DownloadAsBytesByNameAsync(name);
        }

        public byte[] GetFileByName(string name)
        {
            return  gridFS.DownloadAsBytesByName(name);
        }
    }
}