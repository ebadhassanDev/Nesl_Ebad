using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Logging
{
    /// <summary>
    /// Interface for logging messages. Provides methods for different logging levels.
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Logs an informational message on Console Screen.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        void Information(string message);
        /// <summary>
        /// Logs a warning message on Console Screen.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        void Warning(string message);
        /// <summary>
        /// Logs an error message on Console Screen.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="method">The name of the method where the error occurred (optional).</param>
        /// <param name="mailSend">Optional flag indicating if an email notification should be sent (default: false).</param>
        void Error(string message, string method, bool mailSend = default);
        /// <summary>
        /// Logs an unexpected exception of unknown type on Console Screen (or other configured output).
        /// </summary>
        /// <param name="message">The message describing the unexpected behavior.</param>
        /// <param name="method">The name of the method where the exception occurred (optional).</param>
        /// <remarks>
        /// This method is intended for logging unexpected exceptions whose type is unknown. 
        /// It's important to include as much detail as possible in the `message` parameter to aid in debugging.
        /// </remarks>
        void UnknownException(string message, string method = default);
    }
}
