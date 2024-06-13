using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.MailMessageService
{
    /// <summary>
    /// Interface representing a service for sending emails.
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Sends an email message.
        /// </summary>
        /// <param name="message">The `MailMessage` object containing the email details (sender, customer, subject, body).</param>
        void SendMail(MailMessage message);
    }
}
