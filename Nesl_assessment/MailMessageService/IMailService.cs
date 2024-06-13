using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.MailMessageService
{
    public interface IMailService
    {
        void SendMail(MailMessage message);
    }
}
