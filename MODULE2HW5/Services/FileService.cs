using System;
using System.Linq;
using System.IO;
using System.Text;
using MODULE2HW5.Services.Abstractions;

namespace MODULE2HW5.Services
{
    public class FileService : IFileService
    {
        private ConfigService _configService;
        public FileService()
        {
            _configService = new ConfigService();
            FinalFormat = $"{_configService.Config.Path}" +
                          $"{DateTime.UtcNow.ToString(_configService.Config.FileTimeFormat)}" +
                          $"{_configService.Config.FileFormat}";
        }

        private string FinalFormat { get; init; }

        public FileInfo[] GetFiles()
        {
            var files = new DirectoryInfo(_configService.Config.Path).GetFiles().OrderBy(f => f.CreationTime).ToArray();
            return files.ToArray();
        }

        public void CreateFile()
        {
            if (CheckDirectory())
            {
                if (!File.Exists(FinalFormat))
                {
                    File.Create(FinalFormat).Close();
                }
            }
        }

        public void SaveToFile()
        {
            var logger = Logger.Instance;
            using (StreamWriter sw = new StreamWriter(FinalFormat, true))
            {
                sw.WriteLine(logger.StringToWrite);
            }
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
                return true;
            }

            return true;
        }
    }
}