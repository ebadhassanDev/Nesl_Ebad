using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Logging
{
    public class LogService : ILogService
    {
        public void Error(string message, string method, bool mailSend = default) => Console.WriteLine($"Error: {message} on Method: {method} {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        public void Information(string message) => Console.WriteLine($"Success: {message} {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        public void Warning(string message) => Console.WriteLine($"Warning: {message} {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        public void UnknownException(string message, string method) => Console.WriteLine($"Unknown Exception Happer: {message} {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

    }
}
