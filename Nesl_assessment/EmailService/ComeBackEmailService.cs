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
    public class ComeBackEmailService: IMail
    {
        private readonly IMailService mailService;
        private readonly ILogService logService;

        public ComeBackEmailService(IMailService mail, ILogService log)
        {
           this.mailService = mail;
            this.mailService = mail;
        }

        public async Task<bool> SendEmail(string customerEmail, string voucherCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(voucherCode))
                {
                    string body = $"Hi {customerEmail}" +
                        $"<br>We miss you as a customer. Our shop is filled with nice products. Here is a voucher that gives you 50 kr to shop for." +
                        $"<br>Voucher: {voucherCode}" +
                        $"<br><br>Best Regards,<br>EO Team";
                    string subject = "We miss you as a customer";
                    this.SendComeBackEmail(customerEmail: customerEmail, subject: subject, body: body);

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
        private void SendComeBackEmail(string customerEmail, string subject, string body)
        {
            //Create a new MailMessage
            var mailMessage = new MailMessage()
            {
                From = new MailAddress("infor@neilst.com"),
                Subject = subject,
                Body = body
            };
            //Add customer to reciever list
            mailMessage.To.Add(customerEmail);
#if DEBUG
            //Don't send mails in debug mode, just write the emails in console
            logService.Information(message: "Send customer mail to:" + customerEmail);
#else


this.mailService.SendMail(mailMessage);

#endif
        }
    }
}
