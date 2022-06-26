using Microsoft.Extensions.Logging;

namespace Hathor.Common
{
    public class LoggerToConsole<T> : ILogger<T>
    {
        private readonly string _name;
        private Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new()
        {
            [LogLevel.Information] = ConsoleColor.Green,
            [LogLevel.Debug] = ConsoleColor.White,
            [LogLevel.Warning] = ConsoleColor.Yellow,
            [LogLevel.Error] = ConsoleColor.Red
        };

        public LoggerToConsole(string name) => (_name) = (name);

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel) => LogLevels.ContainsKey(logLevel);

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = LogLevels[logLevel];
            Console.WriteLine($"[{eventId.Id,2}: {logLevel}]");

            Console.ForegroundColor = originalColor;
            Console.Write($"{_name} - ");

            Console.ForegroundColor = LogLevels[logLevel];
            Console.Write($"{formatter(state, exception)}");

            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }
    }
}
