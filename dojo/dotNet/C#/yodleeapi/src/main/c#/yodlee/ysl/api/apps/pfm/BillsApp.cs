using System;
using Newtonsoft.Json;

namespace yodlee.ysl.api.apps.pfm
{
    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using Bills = yodlee.ysl.api.beans.Bills;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using GSONParser = yodlee.ysl.api.parsers.GSONParser;
    using System.Collections.Generic;
    

    /// <summary>
    /// 	The BillsApp class provides all bills for a member account, which are the aggregated from a Billing Account.
    /// 
    /// 
    ///   Steps to Use this App: 
    ///   i) doCoBrandLogin(String coBrandUserName, String coBrandPassword)
    ///   ii) doMemberLogin(String userName, String userPassword)
    /// 
    /// 
    /// </summary>
    public class BillsApp
    {
        
        public static readonly string fqcn = typeof(BillsApp).FullName;

        /// <summary>
        /// Return all the Bills of a member Account.
        /// </summary>
        
        
        public static Bills Bills
        {
            get
            {
                string mn = "getBills()";
               
                string BillsURL = LoginApp.localURLVer1 + "bills/";
                List<string> headers = new List<string>();
             string usersessionid =LoginApp.usession;
             string cbrandsessionid = LoginApp.cbsession;
             headers.Add("Authorization:{userSession= "+usersessionid+",cobSession="+cbrandsessionid+"}");
                string jsonResponse = HTTP.doGet(BillsURL, headers);//headers-Authorization headers i.e-member session id and cobrand session id
                Type billtype = typeof(Bills);
                
                Bills bills = (Bills)GSONParser.handleJson(jsonResponse, billtype);
                return bills;
            }
        }
        public static void billsApp()
        {
            Console.WriteLine("BillsApp - TEST - START");
            //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
           
            Bills bills = BillsApp.Bills;
            Console.WriteLine("------------------");
            Console.WriteLine("Bill Id Due Amount");
            Console.WriteLine("------------------");
            Console.WriteLine(bills.ToString());
            Console.WriteLine("------------------");
            LoginApp.readValue();
            
        }
      
        public static void Main(string[] a)
        {
            billsApp();
        }
    }
}