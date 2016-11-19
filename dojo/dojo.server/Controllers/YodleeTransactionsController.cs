using System.Collections.Generic;
using System.Web.Http;
using dojo.server.Models;

namespace dojo.server.Controllers
{
    [RoutePrefix("api/YodleeTransactions")]
    public class YodleeTransactionsController : ApiController
    {
        public IList<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    AcountId = 1,
                    Amout = new Amount { Amout = 111.11, Currency = "GBP" },
                    Description = new Description { Original = "An expense", Simple = "An expense" },
                    CategoryId = 44,
                    Category = "General Merchandise",
                    CategoryType = "EXPENSE",
                    BaseType = "DEBIT",
                    Status = "POSTED",
                    Merchant = new Merchant {Name = "Walmart"},
                    HighLevelCategoryId = 10000004
                }
            };

            return transactions;
        }
    }
}
