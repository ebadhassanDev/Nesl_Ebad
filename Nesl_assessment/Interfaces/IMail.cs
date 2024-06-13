using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Interfaces
{
    public interface IMail
    {
        Task<bool> SendEmail(string customerEmail, string voucherCode = default);
    }
}
