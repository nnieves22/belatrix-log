namespace Log.Loggers
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel);
    }
}
