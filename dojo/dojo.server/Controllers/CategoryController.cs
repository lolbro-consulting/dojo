using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yodlee.ysl.api.apps.pfm;
using yodlee.ysl.api.apps.yaas;
using yodlee.ysl.api.beans;

namespace dojo.server.Controllers
{
    public class CategoryController : ApiController
    {
        private static readonly Lazy<Transactions> transactions = new Lazy<Transactions>(() =>
        {
            LoginApp.doCoBrandLogin();
            LoginApp.doMemberLogin();
            return TransactionApp.Transactions;
        });

        public decimal GetTransactionsTotalForCategory(string category, int timeInterval)
        {
            return transactions.Value.transaction.Where(t => t.Category == category).Sum(t => decimal.Parse(t.Amount.amount));
        }
    }
}