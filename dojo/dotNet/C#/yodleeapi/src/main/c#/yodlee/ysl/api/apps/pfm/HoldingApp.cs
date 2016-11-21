using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace yodlee.ysl.api.apps.pfm
{


    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using Holdings = yodlee.ysl.api.beans.Holdings;
    using Accounts = yodlee.ysl.api.beans.Accounts;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using GSONParser = yodlee.ysl.api.parsers.GSONParser;
   
    

    /// <summary>
    ///  The HoldingApp class provides holdings for a member account. 
    ///  Holdings are Investment accounts which a member has aggregated using Aggregation Apps.
    /// 
    /// 
    ///   Steps to Use this App: 
    ///   i) doCoBrandLogin(String coBrandUserName, String coBrandPassword)
    ///   ii) doMemberLogin(String userName, String userPassword)
    /// 
    ///   Browse all Accounts for member profile: 
    ///   Accounts getHoldings() 
    /// 
    /// 
    /// 
    /// </summary>

    public class HoldingApp
    {

       
        private static readonly string fqcn = typeof(HoldingApp).FullName;

       
        public static Holdings Holdings 
        {
            get
            {
                string mn = "getHoldings()";
                //Console.WriteLine(fqcn + " :: " + mn);
                string holdingsURL = LoginApp.localURLVer1 + "holdings/";
                List<string> headers = new List<string>();
                string usersessionid = LoginApp.usession;
                string cbrandsessionid = LoginApp.cbsession;
                headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
               string jsonResponse = HTTP.doGet(holdingsURL,headers);//heades-Authorization headers i.e-member session id and cobrand sesion id.
                //Console.WriteLine(jsonResponse);
                 Type holdingtype = typeof(Holdings);
                Holdings holdings = (Holdings)GSONParser.handleJson(jsonResponse,holdingtype);
                String type = "";
                //for (int i = 0; i < holdings.holding.Count; i++) { 
                //type = holdings.holding[i].holdingType;
                //if (type == "mutualFund") {
                //    string accountSummaryURL = LoginApp.localURLVer1 + "v1/accounts/";
                //     jsonResponse = HTTP.doGet(accountSummaryURL, headers);//headers-authorization headers i.e-member external sesionid,cobrand external session id
                //    Type account = typeof(Accounts);
                //    Accounts accounts = (Accounts)GSONParser.handleJson(jsonResponse, account);
                //    Console.WriteLine(accounts.ToString());
                //    }
                //}

                return holdings;
            }
        }

        public static Holdings HoldingsWithAsset
        {
            get
            {
                string mn = "getHoldings()";
                //Console.WriteLine(fqcn + " :: " + mn);
                string holdingsURL = LoginApp.localURLVer1 + "holdings/?include=assetClassification";//&assetClassification.classificationType=COUNTRY&assetClassification.classificationValue<>US";
                List<string> headers = new List<string>();
                string usersessionid = LoginApp.usession;
                string cbrandsessionid = LoginApp.cbsession;
                headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
                string jsonResponse = HTTP.doGet(holdingsURL, headers);//heades-Authorization headers i.e-member session id and cobrand sesion id.
                //Console.WriteLine(jsonResponse);
                Type holdingtype = typeof(Holdings);
                Holdings holdings = (Holdings)GSONParser.handleJson(jsonResponse, holdingtype);
                return holdings;
            }
        }

       

        public static void holdingApp(int id)
        {
            Console.WriteLine("HoldingApp - TEST - START");
            if (id == 1)
            {
                //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
                Console.WriteLine("------------------------");
                Console.WriteLine("HoldingId AccountId Description HoldingType Price");
                Console.WriteLine("------------------------");
                Holdings holdings = HoldingApp.Holdings;
                Console.WriteLine(holdings.ToString());
            }
            else {
                //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
                Console.WriteLine("------------------------");
                Console.WriteLine("HoldingId AccountId Description HoldingType Value ClassificationType ClassificationValue allocation");
                Console.WriteLine("------------------------");
                Holdings holdings = HoldingApp.HoldingsWithAsset;
                Console.WriteLine(holdings.ToString());
            }
            LoginApp.readValue();
        }
      
        public static void Main(string[] a)
        {
            holdingApp(1);
        }
    }
}