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
                var DirPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Log";

                var CheckFilePathResult = CheckFilePath(DirPath);
                if (CheckFilePathResult.Equals(true))
                {
                    LogPath = DirPath + @"\\" + DateTime.Now.ToString("yyyyMMdd");
                    var LogPosition = File.Create(LogPath);
                    LogPosition.Close();

                }
            }
            else
            {
                LogPath = PathForLogFile;
            }
        }
        public bool CheckFilePath(string path)
        {
            var result = false;

            while (result.Equals(false))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    
                    result = true;
                }
                catch (Exception ex)
                {
                    //Create Directory Fail
                }
            }

            return result;
        }
        public void WriteFile(LogLevel logLevel, string message)
        {
            var streamWriter = new StreamWriter(LogPath, true);
            var RecordDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var LogMessage = string.Concat(logLevel.ToString(), " || ", RecordDateTime, " || ", message);    
            streamWriter.WriteLine(LogMessage);
            streamWriter.Close();
        }
    }
    
}
