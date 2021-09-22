using System;
using System.Linq;
using System.IO;
using MODULE2HW5.Services.Abstractions;

namespace MODULE2HW5.Services
{
    public class FileService : IFileService
    {
        private ConfigService _configService;
        public FileService()
        {
            _configService = new ConfigService();
        }

        public FileInfo[] GetFiles()
        {
            var files = new DirectoryInfo(_configService.Config.Path).GetFiles().OrderBy(f => f.CreationTime).ToArray();
            return files.ToArray();
        }

        public string CreateFile()
        {
            string finalFormat = $"{_configService.Config.Path}" +
                                 $"{DateTime.UtcNow.ToString(_configService.Config.FileTimeFormat)}" +
                                 $"{_configService.Config.FileFormat}";
            Console.WriteLine(finalFormat);
            if (CheckDirectory())
            {
               File.Create(finalFormat).Close();
               return finalFormat;
            }

            return finalFormat;
        }

        public void SaveToFile()
        {
            string pathFile = CreateFile();
            var logger = Logger.Instance;
            File.WriteAllText(pathFile, logger.Stringbuilder.ToString());
        }

        public void DeleteFiles()
        {
            var files = GetFiles();
            var directoryAmountOffiles = files.Length;
            foreach (var file in files)
            {
                if (directoryAmountOffiles > _configService.Config.FileLimitInFolder)
                {
                    File.Delete(file.ToString());
                    directoryAmountOffiles--;
                }
            }

            CreateFile();
        }

        public bool CheckDirectory()
        {
            var amountOfFiles = GetFiles().Length;
            if (amountOfFiles > _configService.Config.FileLimitInFolder)
            {
                DeleteFiles();
                return false;
            }

            return true;
        }
    }
}