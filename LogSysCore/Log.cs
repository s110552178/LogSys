using LogSysCore.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSysCore
{
    public class Log
    {
        string LogPath = string.Empty;
        public Log(string PathForLogFile = "")
        {
            if (string.IsNullOrEmpty(PathForLogFile))
            {
                var DateTimeNow = DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(@"/Log"))
                {
                    Directory.CreateDirectory(@"/Log");
                }
                if (!File.Exists(@"/Log/"+DateTimeNow))
                {
                    var CF = File.Create(@"/Log/" + DateTimeNow);
                    CF.Close();
                }
                LogPath = @"/Log/" + DateTimeNow;
            }
            else
            {
                LogPath = PathForLogFile;
            }
        }
        
        public void WriteMessageWithLevel(LogLevel logLevel, string message)
        {
            var streamWriter = new StreamWriter(LogPath, true);
            var RecordDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var LogMessage = string.Concat(logLevel.ToString(), " || ", RecordDateTime, " || ", message);    
            streamWriter.WriteLine(LogMessage);
            streamWriter.Close();
        }
        public void WriteMessage(string message)
        {
            var streamWriter = new StreamWriter(LogPath, true);
            var RecordDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var LogMessage = string.Concat(RecordDateTime, " || ", message);
            streamWriter.WriteLine(LogMessage);
            streamWriter.Close();
        }
    }
    
}
