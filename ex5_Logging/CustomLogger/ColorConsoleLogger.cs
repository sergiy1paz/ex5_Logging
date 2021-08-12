using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace ex5_Logging.CustomLogger
{
    public class ColorConsoleLogger : ILogger
    {
        private static readonly object _lock = new object();
        

        private readonly string _name;
        public ColorConsoleLogger(string name)
        {
            _name = name;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                ChangeConsoleColor(logLevel);
                Console.WriteLine(formatter(state, exception));
                SetDefaultConsoleColor();
            }

        }

        private void ChangeConsoleColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
        }

        private void SetDefaultConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        
    }
}
