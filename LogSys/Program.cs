using LogSysCore;

namespace LogSys
{
    class Program
    {
        static void Main(string[] args)
        {
            var Logs = new Log();
            Logs.WriteFile(LogSysCore.Enum.LogLevel.Info, "TestInfoMessage");
            Logs.WriteFile(LogSysCore.Enum.LogLevel.Critical, "TestCriticalMessage");
            Logs.WriteFile(LogSysCore.Enum.LogLevel.Warning, "TestWarningMessage");
        }
    }
}
