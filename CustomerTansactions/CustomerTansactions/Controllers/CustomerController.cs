using CustomerTransactions.Models;
using System.Linq;
using System.Web.Http;

namespace CustomerTransactions.Controllers
{
    public class CustomerController : ApiController
    {
        private IHttpActionResult GetCustomer(long? id = null, string email = null)
        {
            if (!id.HasValue && email == null) {
                return BadRequest("No inquiry criteria");
            }

            if(id.HasValue && id.Value >= 10000000000)
            {
                return BadRequest("Invalid Customer ID");
            }

            if (email != null  && email.Length > 25)
            {
                return BadRequest("Invalid Email");
            }

            using (var ctx = new CustomerTransactionContext())
            {
                try
                {
                    IQueryable<Customer> query;
                    if (id.HasValue && email != null)
                    {
                        query = ctx.Customers.Where(c => c.CustomerID == id && c.EMail == email.ToLower());
                    }
                    else if (id.HasValue)
                    {
                        query = ctx.Customers.Where(c => c.CustomerID == id);
                    }
                    else
                    {
                        query = ctx.Customers.Where(c => c.EMail == email.ToLower());
                    }
                    var customer = query
                        .Select(c => new
                        {
                            customerID = c.CustomerID,
                            email = c.EMail,
                            name = c.Name,
                            mobile = c.Mobile,
                            transactions = c.Transactions.OrderByDescending(t => t.Date).Take(5).Select(t => new
                            {
                                id = t.ID,
                                date = t.Date,
                                amount = t.Amount,
                                currency = t.Currency,
                                status = t.Status
                            }).ToList()
                        })
                        .FirstOrDefault();
                    if (customer == null)
                    {
                        return NotFound();
                    }
                    return Ok(new
                    {
                        customer.customerID,
                        customer.email,
                        customer.name,
                        customer.mobile,
                        transactions = customer.transactions.Select(t => new
                        {
                            t.id,
                            date = t.date.HasValue ? t.date.Value.ToString("dd/MM/yy HH:mm") : "",
                            amount = t.amount.ToString("#,##0.00"),
                            t.currency,
                            t.status
                        })
                    });
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

        public IHttpActionResult Get(long id)
        {
            return GetCustomer(id);
        }

        public IHttpActionResult Get(string email)
        {
            return GetCustomer(null, email);
        }

        public IHttpActionResult Get(long? id, string email)
        {
            return GetCustomer(id, email); ;
        }
    }
}
