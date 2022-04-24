using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Hathor.Api.Test
{
    internal class DebugLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Debug.WriteLine($"[Test] [{logLevel}] {state}");
        }
    }
}
