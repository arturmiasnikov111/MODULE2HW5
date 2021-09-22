using System.IO;

namespace MODULE2HW5.Services.Abstractions
{
    public interface IFileService
    {
        public FileInfo[] GetFiles();
        public string CreateFile();
        public void SaveToFile();
        public void DeleteFiles();
        public bool CheckDirectory();
    }
}