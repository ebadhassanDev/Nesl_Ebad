using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using Nesl_assessment.MailMessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.EmailService
{
    public class WelcomeEmailService : IMail
    {
        private readonly IMailService mailService;
        private readonly ILogService logService;

        public WelcomeEmailService(IMailService mail, ILogService log)
        {
            this.mailService = mail;
            this.logService = log;
        }
        public async Task<bool> SendEmail(string customerEmail, string voucherCode = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(customerEmail))
                {
                    string body = $"Hi {customerEmail} <br>We would like to welcome you as customer on our site!<br><br>Best Regards,<br>EO Team";
                    string subject = "Welcome as a new customer at EO!";
                    this.SendWelcomeEmail(customerEmail: customerEmail, subject: subject, body: body);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logService.Error(message: ex.Message, method: nameof(this.SendEmail), mailSend: false);
                return false;
            }
        }
        private void SendWelcomeEmail(string customerEmail, string subject, string body)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress("info@EO.com"),
                Subject = subject,
                Body = body
            };
            //Add customer to reciever list
            mailMessage.To.Add(customerEmail);
#if DEBUG
            //Don't send mails in debug mode, just write the emails in console
            logService.Information(message: $"Send new customer mail to: {customerEmail}");
#else
	this._mailService.SendMail(mailMessage);
#endif
        }
    }
}
