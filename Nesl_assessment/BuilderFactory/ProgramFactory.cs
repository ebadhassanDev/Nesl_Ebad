using Microsoft.Extensions.DependencyInjection;
using Nesl_assessment.EmailService;
using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using Nesl_assessment.MailMessageService;
using Nesl_assessment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.BuilderFactory
{
    public class ProgramFactory
    {
        public static Program InitilizeServiceFactory()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IMailService, MailService>();
            services.AddSingleton<IMail, WelcomeEmailService>();
            services.AddSingleton<IMail, ComeBackEmailService>();

            var serviceProvider = services.BuildServiceProvider();
            return new Program
             (
                 cus: serviceProvider.GetService<ICustomerRepository>(),
                mail: serviceProvider.GetService<IMailService>(),
                log: serviceProvider.GetService<ILogService>()
             );
        }
    }
}
