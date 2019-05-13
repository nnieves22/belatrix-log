using Log.Loggers;
using System;

namespace Log
{
    public class ConsoleLogger : ILogger
    {
        private const ConsoleColor InfoMessageColor = ConsoleColor.White;
        private const ConsoleColor WarnignMessageColor = ConsoleColor.Yellow;
        private const ConsoleColor ErrorMessageColor = ConsoleColor.Red;

        public void Log(string message, LogLevel logLevel)
        {
            var originalColor = Console.ForegroundColor;

            switch(logLevel)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = InfoMessageColor;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = WarnignMessageColor;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ErrorMessageColor;
                    break;
            }

            Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}-{ message}");
            Console.ForegroundColor = originalColor;
        }

    }
}
