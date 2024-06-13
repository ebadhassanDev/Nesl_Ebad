using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> SendEmailWithVoucherCode(string code);
        Task<bool> SendEmailToNewCustomers();
    }
}
