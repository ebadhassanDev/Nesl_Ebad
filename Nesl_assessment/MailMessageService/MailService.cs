using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.MailMessageService
{
    public class MailService: IMailService
    {
        public void SendMail(MailMessage message)
        {
            var smtp = new SmtpClient("neslSmtpService");
            smtp.Send(message);
        }
    }
}
