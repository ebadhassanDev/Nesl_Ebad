using Nesl_assessment.BuilderFactory;
using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using Nesl_assessment.MailMessageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nesl_assessment
{
    /// <summary>
    /// Main class for application
    /// </summary>
    public class Program
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailService _mailService;
        private readonly ILogService _logService;
        public Program(ICustomerRepository cus, IMailService mail, ILogService log)
        {
            this._customerRepository = cus;
            this._mailService = mail;
            this._logService = log;
        }

        /// <summary>
        /// This application is run everyday
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "Send Customer Email Utility";
            Console.WriteLine("##########################################");
            Console.WriteLine("Starting Application......");

            var program = ProgramFactory.InitilizeServiceFactory();

            program.RunProgram().ConfigureAwait(false);

            Console.ReadKey();
        }
        private async Task RunProgram()
        {
            bool success = await this._customerRepository.SendEmailToNewCustomers().ConfigureAwait(false);
            if (success) this._logService.Information($"Email successfully send to New Customers");

            if (!success) this._logService.Error(message: "Something went wrong", method: nameof(_customerRepository.SendEmailToNewCustomers), mailSend: success);

            success = await this._customerRepository.SendEmailWithVoucherCode("EOComeBackToUs").ConfigureAwait(false);
            if (success) this._logService.Information($"Emails successfully send to Voucher code customers");

            if (!success) this._logService.Error(message: "Something went wrong", method: nameof(_customerRepository.SendEmailWithVoucherCode), mailSend: success);

        }
    }
}
