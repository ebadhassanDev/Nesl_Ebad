using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Interfaces
{
    public interface IMail
    {
        /// <summary>
        /// Sends an email based on the specified type and customer information.
        /// </summary>
        /// <param name="customerEmail">The email address of the customer.</param>
        /// <param name="voucherCode">Optional voucher code to be included in the email (default: null).</param>
        /// <returns>A task that returns `true` if the email sending process was successful, `false` otherwise.</returns>
        Task<bool> SendEmail(string customerEmail, string voucherCode = default);
    }
}
