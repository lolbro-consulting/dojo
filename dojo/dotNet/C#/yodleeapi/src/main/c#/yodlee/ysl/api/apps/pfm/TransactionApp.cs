using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace yodlee.ysl.api.apps.pfm
{


    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using Transactions = yodlee.ysl.api.beans.Transactions;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using GSONParser = yodlee.ysl.api.parsers.GSONParser;
    /// <summary>
    ///  The TransactionApp class provides Transaction details. 
    /// 
    /// 
    ///   Steps to Use this App: 
    ///   i) doCoBrandLogin(String coBrandUserName, String coBrandPassword)
    ///   ii) doMemberLogin(String userName, String userPassword)
    /// 
    ///   Browse all Accounts for member profile: 
    ///   Accounts getTransactions() 
    /// 
    ///
    /// 
    /// </summary>
   public class TransactionApp
    {
        private static readonly string fqcn = typeof(TransactionApp).FullName;
        public static Transactions Transactions
        {
            get
            {
                string mn = "getTransactions()";
               string transactionsURL = LoginApp.localURLVer1 + "transactions?fromDate=2013-01-01&toDate=2013-12-01";
               List<string> headers = new List<string>();
               string usersessionid = LoginApp.usession;
               string cbrandsessionid = LoginApp.cbsession;
               headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
               string jsonResponse = HTTP.doGet(transactionsURL, headers);//heades-Authorization headers i.e-member session id and cobrand sesion id.
                Type transtype = typeof(Transactions);
                Transactions transactions = (Transactions)GSONParser.handleJson(jsonResponse, transtype);
                return transactions;
            }
        }
        public static void transactionApp()
        {
            Console.WriteLine("TransactionApp - TEST - START");
            //LoginApp.doLogin("yodlee_10000004", "yodlee123", "sprint13last30days", "TEST@123");
            Transactions transactions = TransactionApp.Transactions;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("TransactionId Amount BaseType");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(transactions.ToString());
            Console.WriteLine("-------------------------------");
            LoginApp.readValue();
            //Console.ReadLine();
        }
      
        public static void Main(string[] a)
        {
            transactionApp();
        }
    }
}