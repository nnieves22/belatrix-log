using Log.Loggers;
using System;
using System.IO;
using System.Threading;

namespace Log
{
    public class FileLogger : ILogger
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message, LogLevel logLevel)
        {
            var logMessage = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")} - {logLevel.ToString()} - {message}";

            // Set Status to Locked
            _readWriteLock.EnterWriteLock();
            try
            {
                var fileName = $"{_filePath}LogFile{DateTime.UtcNow.ToString("yyyyMMdd")}.txt";
                // Append text to the file
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(logMessage);
                    sw.Close();
                }
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}
