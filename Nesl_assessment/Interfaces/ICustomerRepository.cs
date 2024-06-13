using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Interfaces
{
    /// <summary>
    /// Interface representing a repository for accessing and managing customer data.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Sends emails to a specific type of customer with a voucher code included.
        /// </summary>
        /// <param name="vouchorCode">The voucher code to be included in the email.</param>
        /// <returns>A task that returns `true` if the email sending process was successful, `false` otherwise.</returns>
        Task<bool> SendEmailWithVoucherCode(string code);
        /// <summary>
        /// Sends emails to customers who are registered currently or previously.
        /// </summary>
        /// <returns>A task that returns `true` if the email sending process was successful, `false` otherwise.</returns>
        Task<bool> SendEmailToNewCustomers();
    }
}
