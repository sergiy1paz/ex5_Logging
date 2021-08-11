using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ex5_Logging.CustomLogger;

namespace ex5_Logging.Extensions
{
    public static class ILogginBuilderExtension
    {
        public static ILoggingBuilder AddColorConsole(this ILoggingBuilder builder)
        {
            builder.AddProvider(new ColorConsoleLoggerProvider());
            return builder;
        }
    }
}
