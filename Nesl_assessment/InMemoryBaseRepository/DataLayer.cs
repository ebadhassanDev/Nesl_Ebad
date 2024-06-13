using Nesl_assessment.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.InMemoryBaseRepository
{
    public class DataLayer
    {
        /// <summary>
		/// Mockup method for all customers
		/// </summary>
        public static IEnumerable<CustomerDocument> GetCustomersList(Func<CustomerDocument, bool> predicate = null)
        {
            var customerDocuments = new List<CustomerDocument>()
            {
                new CustomerDocument(){Email = "mail1@mail.com", CreatedDateTime = DateTime.Now.AddHours(-7)},
                new CustomerDocument(){Email = "mail2@mail.com", CreatedDateTime = DateTime.Now.AddDays(-1)},
                new CustomerDocument(){Email = "mail3@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-6)},
                new CustomerDocument(){Email = "mail4@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-1)},
                new CustomerDocument(){Email = "mail5@mail.com", CreatedDateTime = DateTime.Now.AddMonths(-2)},
                new CustomerDocument(){Email = "mail6@mail.com", CreatedDateTime = DateTime.Now.AddDays(-5)}
            };
            if (predicate != null) 
            {
                customerDocuments = customerDocuments.Where(predicate).ToList();
            }
            return customerDocuments;
        }
        /// <summary>
        /// Mockup method for listing all orders
        /// </summary>
        public static IEnumerable<OrderDocument> GetOrdersList(Func<OrderDocument, bool> predicate = null)
        {
            var ordersDocuments = new List<OrderDocument>()
            {
                new OrderDocument(){CustomerEmail = "mail3@mail.com", OrderDatetime = DateTime.Now.AddMonths(-6)},
                new OrderDocument(){CustomerEmail = "mail5@mail.com", OrderDatetime = DateTime.Now.AddMonths(-2)},
                new OrderDocument(){CustomerEmail = "mail6@mail.com", OrderDatetime = DateTime.Now.AddDays(-2)}
            };
            if (predicate != null)
            {
                ordersDocuments = ordersDocuments.Where(predicate).ToList();
            }
            return ordersDocuments;
        }
    }
}
