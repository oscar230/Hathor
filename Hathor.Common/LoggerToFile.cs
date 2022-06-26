using Microsoft.Extensions.Logging;

namespace Hathor.Common
{
    public class LoggerToFile<T> : ILogger<T>, IDisposable
    {
        private readonly FileInfo _loggerFile;
        private readonly FileStream _loggerFileStream;

        public LoggerToFile()
        {
            _loggerFile = new FileInfo($"log_{DateTime.Now}.txt");
            _loggerFile.Create();
            _loggerFileStream = _loggerFile.OpenWrite();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _loggerFileStream.Flush();
            _loggerFileStream.Dispose();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _loggerFile.Exists && _loggerFileStream.CanWrite;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}
