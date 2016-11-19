using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yodlee.ysl.api.apps.pfm;
using yodlee.ysl.api.apps.yaas;
using yodlee.ysl.api.beans;


namespace dojo.server.Controllers
{
    public class YodleeController : ApiController
    {
        private static readonly Lazy<Transactions> transactions = new Lazy<Transactions>(() =>
        {
            LoginApp.doCoBrandLogin();
            LoginApp.doMemberLogin();
            return TransactionApp.Transactions;
        });

        public HttpResponseMessage GetTransactions()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public decimal GetTransactionsTotalForCategory(string category)
        {
            return transactions.Value.transaction.Where(t => t.Category == category).Sum(t => decimal.Parse(t.Amount.amount));
        }
    }
}