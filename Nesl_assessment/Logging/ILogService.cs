using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Logging
{
    public interface ILogService
    {
        void Information(string message);
        void Warning(string message);
        void Error(string message, string method, bool mailSend = default);
        void UnknownException(string message, string method = default);
    }
}
