using MongoDB.Driver.GridFS;

namespace AthenaEDU.Services
{
    public class FileSystemService
    {
        private static MongoDBConnection _connection{ get; set; }
        public FileSystemService(MongoDBConnection connection) {
            _connection = connection;
        }
        /*public static async Task UploadImageToDbAsync(Stream fs, string name)
        {
            var gridFS = new GridFSBucket(_connection.database);

            await gridFS.UploadFromStreamAsync(name, fs);
        }

        public static void DownloadToLocal(string name)
        {
            var gridFS = new GridFSBucket(_connection.database);
            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/Images/")}{name}", FileMode.OpenOrCreate))
            {
                gridFS.DownloadToStreamByName(name, fs);
            }
        }*/
    }
}