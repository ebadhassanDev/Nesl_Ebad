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
    /// <summary>
    /// <para>This class is responsible for creating and configuring the application's dependencies using dependency injection.</para> 
    /// <para>It defines a static method `IntializeServiceFactory` that sets up and returns a configured `Program` objects as Services.</para>
    /// </summary>
    /// <remarks>
    /// <para>This class utilizes dependency injection to provide a flexible way to manage application dependencies.</para>
    /// </remarks>
    public class ProgramFactory
    {
        /// <summary>
        /// This static method creates a new instance of `ServiceCollection` to register dependencies.
        /// It registers services as singletons and builds the service provider. Finally, it creates and configures a new `Program` object.
        /// </summary>
        /// <returns>A configured instance of the `Program` class.</returns>
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
