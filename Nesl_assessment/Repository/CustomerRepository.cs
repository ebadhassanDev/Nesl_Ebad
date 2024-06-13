using Nesl_assessment.InMemoryBaseRepository;
using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMail mailService;
        private readonly ILogService log;
        public CustomerRepository(IMail mailService, ILogService log)
        {
            this.mailService = mailService;
            this.log = log;
        }

        public async Task<bool> SendEmailToNewCustomers()
        {
            try
            {
                int customerCount = DataLayer.GetCustomersList().Count(s => s.CreatedDateTime > DateTime.Now.AddDays(-1));

                int batchSize = 2;
                int skip = 0;

                for (int i = 0; i < customerCount; i += batchSize)
                {
                    var newCustomers = DataLayer.GetCustomersList()
                         .Where(s => s.CreatedDateTime > DateTime.Now.AddDays(-1))
                         .Skip(skip)
                         .Take(batchSize)
                         .ToList();
                    foreach (var customer in newCustomers)
                    {
                        await this.mailService.SendEmail(customer.Email);
                    }
                    skip += batchSize;
                }
                return true;
            }
            catch (Exception ex)
            {
                this.log.Error(message: ex.Message, method: nameof(this.SendEmailToNewCustomers), mailSend: false);
                return false;
            }
        }
        public async Task<bool> SendEmailWithVoucherCode(string voucherCode)
        {
            try
            {
                int customerCount = DataLayer.GetCustomersList().Count();

                int batchSize = 2;
                int skip = 0;
                for (int i = 0; i < customerCount; i += batchSize)
                {

                    var cutonmers = DataLayer.GetCustomersList()
                        .Skip(skip)
                        .Take(batchSize);
                    foreach (var customer in cutonmers)
                    {
                        if (DataLayer.GetOrdersList().Any(s => s.CustomerEmail == customer.Email))
                            continue;
                        await this.mailService.SendEmail(customerEmail: customer.Email);
                    }

                    skip += batchSize;
                }

                return true;
            }
            catch (Exception ex)
            {
                this.log.Error(message: ex.Message, method: nameof(this.SendEmailWithVoucherCode), mailSend: false);
                return false;
            }
        }
    } 
}
