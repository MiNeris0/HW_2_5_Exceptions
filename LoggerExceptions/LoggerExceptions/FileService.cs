using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace LoggerExceptions
{
    public class FileService
    {
        public static Config Config { get; set; }
        public static string Location { get; set; }

        public static void Run()
        {
            ReadJson();
            CreateDirectory();
        }
        public static void WriteAllInFile(string record)
        {
            var filePath = Path.Combine(Config.Logger.DirectoryPath, Config.Logger.FileName, Config.Logger.FileExtension);
            File.WriteAllText(filePath, record);
        }

        private static void ReadJson()
        {
            Config = new Config();
            var configFile = File.ReadAllText(@"D:\C#\A-level_C#\Projects\HW_2_5_Exceptions\LoggerExceptions\LoggerExceptions\config.json");
            Config = JsonConvert.DeserializeObject<Config>(configFile);
        }

        private static void CreateDirectory()
        {
            bool directory = Directory.Exists(Config.Logger.DirectoryPath);

            if (!directory)
            {
                Directory.CreateDirectory(Config.Logger.DirectoryPath);
            }
        }
    }
}
