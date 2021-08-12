using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ex5_Logging.CustomLogger
{
    [ProviderAlias("CustomLogger")]
    public class ColorConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ColorConsoleLogger(categoryName);
        }

        public void Dispose()
        {
            
        }
    }
}
