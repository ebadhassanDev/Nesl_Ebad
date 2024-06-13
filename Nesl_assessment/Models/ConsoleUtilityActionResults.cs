using Nesl_assessment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Models
{
    public class ConsoleUtilityActionResults
    {
        public string ErrorMessage { get; set; }
        public ConsoleErrorType ErrorType { get; set; }
    }
    public class ConsoleUtilityActionResults<T> : ConsoleUtilityActionResults
    {
        public T Result { get; set; }
    }
}
