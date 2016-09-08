using LogSysCore;

namespace LogSys
{
    class Program
    {
        static void Main(string[] args)
        {
            var Logs = new Log();
            Logs.WriteMessageWithLevel(LogSysCore.Enum.LogLevel.Info, "TestInfoMessage");
            Logs.WriteMessageWithLevel(LogSysCore.Enum.LogLevel.Critical, "TestCriticalMessage");
            Logs.WriteMessageWithLevel(LogSysCore.Enum.LogLevel.Warning, "TestWarningMessage");
            Logs.WriteMessage("TestMessage");
        }
    }
}
