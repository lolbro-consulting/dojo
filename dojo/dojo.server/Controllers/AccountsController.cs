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
using dojo.server.Models;
using yodlee.ysl.api.apps.pfm;
using yodlee.ysl.api.apps.yaas;
using yodlee.ysl.api.beans;


namespace dojo.server.Controllers
{
    public class AccountsController : ApiController
    {
        private static readonly Lazy<Accounts> accounts = new Lazy<Accounts>(() =>
        {
            LoginApp.doCoBrandLogin();
            LoginApp.doMemberLogin();
            return AccountApp.getAccounts();
        });

        public AccountDetails GetTransactionsTotalForCategory(string accountType)
        {
            var total = accounts.Value.account.Where(t => t.AccountType == accountType).Sum(t => decimal.Parse(t.balance.amount));
            var count = accounts.Value.account.Count(t => t.AccountType == accountType);

            return new AccountDetails {Count = count, Balance = total};
        }
    }
}