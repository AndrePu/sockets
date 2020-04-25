using System;

namespace SocketCommon.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + ": ERROR - " + message);
        }
    }
}
