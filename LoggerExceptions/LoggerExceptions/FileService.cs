using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

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
        public static void WriteAllInFile(LogRecord[] records)
        {
            string directory = @"D:\C#\A-level_C#\Projects\HW_2_5_Exceptions\LoggerExceptions\Logs";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] files = directoryInfo.GetFiles("*.txt");
            int length = files.Length;
            char count = '0';

            switch (length)
            {
                case 0:
                    count = '0';
                    break;
                case 1:
                    count = '1';
                    break;
                case 2:
                    count = '2';
                    break;
                case 3:
                    Array.Sort(files, (x, y) => x.CreationTime.CompareTo(y.CreationTime));

                    string fileNameToDelete = files[0].Name;
                    count = fileNameToDelete[^5];
                    System.IO.File.Delete(Path.Combine(directory, fileNameToDelete));
                    break;
                default:
                    break;
            }

            WriteInFile(records, ref directory, count);
        }

        private static void ReadJson()
        {
            Config = new Config();
            var configFile = System.IO.File.ReadAllText(@"D:\C#\A-level_C#\Projects\HW_2_5_Exceptions\LoggerExceptions\LoggerExceptions\config.json");
            Config = JsonConvert.DeserializeObject<Config>(configFile);
        }

        private static void CreateDirectory()
        {
            bool directory = Directory.Exists("Logs/");

            if (!directory)
            {
                Directory.CreateDirectory("Logs/");
            }
        }

        private static void WriteInFile(LogRecord[] records, ref string directory, char count)
        {
            for (int i = 0; i < records.Length; i++)
            {
                System.IO.File.WriteAllText($@"{directory}\log_{count}.txt", Logger.Instance.GetText());

                if (records[i + 1] is null)
                {
                    break;
                }
            }
        }
    }
}
