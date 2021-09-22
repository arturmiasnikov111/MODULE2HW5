using System;
using System.Text;
using System.IO;
using MODULE2HW5.Enums;

namespace MODULE2HW5
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private Logger()
        {
            Stringbuilder = new StringBuilder();
        }

        public static Logger Instance => _instance;

        public StringBuilder Stringbuilder { get; }

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

        private StringBuilder WriteText(LogType logType, string textToWrite)
        {
            Stringbuilder.Append($"{DateTime.Now} : [{logType}] : {textToWrite} {Environment.NewLine}");
            return Stringbuilder;
        }
    }
}