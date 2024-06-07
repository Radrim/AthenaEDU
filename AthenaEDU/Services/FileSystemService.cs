using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace AthenaEDU.Services
{
    public class FileSystemService
    {
        private static MongoDBConnection _connection{ get; set; }
        public FileSystemService(MongoDBConnection connection) {
            _connection = connection;
        }
        
        private String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgSource/")}";

        private String pathCreate =
            $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgCreate/")}";

        private String pathList = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgList/")}";

        private readonly ILogger<FileSystemService> _logger;
        
        public static List<String> UploadImageToDb(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Athena");
            List<String> listNames = new List<string>();
            List<String> imgNames = GetNamesOfDir(folder);
            
            foreach (var name in imgNames)
            {
                listNames.Add(name);
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{path}{name}", FileMode.Open))
                {
                    gridFS.UploadFromStream(name, fs);
                }
            }

            return imgNames;
        }
        
        public void UploadCreateImgToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Athena");


            List<String> imgNames = GetNamesOfDir("imgCreate");

            foreach (var name in imgNames)
            {
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{pathCreate}{name}", FileMode.Open))
                {
                    gridFS.UploadFromStream(name, fs);
                }
            }
        }
        
        public static List<String> GetNamesOfDir(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";

            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            DirectoryInfo info = new DirectoryInfo($"{path}");

            List<String> listNames = new List<string>();

            foreach (var item in info.GetFiles())
            {
                listNames.Add(item.Name);
            }

            return listNames;
        }
        
        
        public static String GetNameOfDir(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
        
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            DirectoryInfo info = new DirectoryInfo($"{path}");

            List<String> listNames = new List<string>();
        
            foreach (var item in info.GetFiles())
            {
                listNames.Add(item.Name);
            }
        
            
            if (listNames.Count == 1)
            {
                return listNames[0].ToString();;
            }
            return "";
        }
        
        public static void DownloadToLocalByName(String name, String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            List<String> imgNames = GetFindByName();
            List<String> loadImgNames = new List<string>();

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Athena");
            var gridFS = new GridFSBucket(database);

            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";

            try
            {
                using (FileStream fs = new FileStream($"{path}{name}", FileMode.CreateNew))
                {
                    gridFS.DownloadToStreamByName(name, fs);
                }

                loadImgNames.Add(name);
            }
            catch (Exception e)
            {
                //  Console.WriteLine($"a file named {name} already exists");
                // _logger.LogError($"a file named {name} already exists");
            }
        }
        
        public static List<String> GetFindByName()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Athena");
            var gridFS = new GridFSBucket(database);
            var collection = database.GetCollection<GridFSFileInfo>("fs.files");

            var strNames = collection.Find(x => x.Filename != null).ToEnumerable<GridFSFileInfo>();

            return strNames.Select(x => x.Filename).ToList<String>();
        }
        
        public static void RemoveFolder(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.GetFiles().Length != 0)
            {
                foreach (FileInfo f in dirInfo.GetFiles())
                {
                    f.Delete();
                }    
            }
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