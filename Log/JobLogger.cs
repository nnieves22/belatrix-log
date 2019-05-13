using Log.Exceptions;
using System.Configuration;

namespace Log
{
    public class JobLogger
    {
        private readonly bool _logToFile;
        private readonly bool _logToConsole;
        private readonly bool _logToDatabase;
        private readonly LogLevel _logVerbosityLevel;
        private readonly DbLogger _dbLogger;
        private readonly FileLogger _fileLogger;
        private readonly ConsoleLogger _consoleLogger;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, LogLevel logVerbosityLevel)
        {
            _logToFile = logToFile;
            _logToConsole = logToConsole;
            _logToDatabase = logToDatabase;
            _logVerbosityLevel = logVerbosityLevel;

            if (!_logToConsole && !_logToDatabase && !_logToFile)
                throw new InvalidConfigurationException();

            if (logToDatabase)
                _dbLogger = new DbLogger(ConfigurationManager.AppSettings["ConnectionString"]);

            if (logToFile)
                _fileLogger = new FileLogger(ConfigurationManager.AppSettings["LogFileDirectory"]);

            if (logToConsole)
                _consoleLogger = new ConsoleLogger();
        }

        public void LogMessage(string message, LogLevel logLevel)
        {
            message = message.Trim();

            if (string.IsNullOrEmpty(message))
                return;

            if ((int) _logVerbosityLevel > (int)logLevel)
                return;

            if (_logToDatabase)
                _dbLogger.Log(message, logLevel);

            if (_logToFile)
                _fileLogger.Log(message, logLevel);

            if (_logToConsole)
                _consoleLogger.Log(message, logLevel);
        }
    }
}
