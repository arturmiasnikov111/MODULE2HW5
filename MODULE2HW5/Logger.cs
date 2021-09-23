using System;
using System.Threading;
using System.Text;
using MODULE2HW5.Enums;
using MODULE2HW5.Services;

namespace MODULE2HW5
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private FileService _fileService;
        private Logger()
        {
            Stringbuilder = new StringBuilder();
            _fileService = new FileService();
        }

        public static Logger Instance => _instance;

        public StringBuilder Stringbuilder { get; }
        public string StringToWrite { get; set; }

        public void Info(string textToWrite)
        {
            WriteText(LogType.Info, textToWrite);
        }

        public void Error(string textToWrite)
        {
            WriteText(LogType.Error, textToWrite);
        }

        public void Warning(string textToWrite)
        {
            WriteText(LogType.Warning, textToWrite);
        }

        public void GetCurrentText()
        {
            Console.Write(Stringbuilder.ToString());
        }

        public void Clean()
        {
            Stringbuilder.Clear();
        }

        private void WriteText(LogType logType, string textToWrite)
        {
            StringToWrite = $"{DateTime.Now} : [{logType}] : {textToWrite} {Environment.NewLine}";
            Stringbuilder.Append(StringToWrite);
            _fileService.SaveToFile();
        }
    }
}