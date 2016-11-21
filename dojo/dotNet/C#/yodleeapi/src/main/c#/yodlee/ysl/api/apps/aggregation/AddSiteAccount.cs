using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace yodlee.ysl.api.apps.aggregation
{
    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using Provider = yodlee.ysl.api.beans.Provider;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using yodlee.ysl.api.aggregation;
    using yodlee.ysl.api.beans;
    public class AddSiteAccount
    {
       
        private static readonly string fqcn = typeof(AddSiteAccount).FullName; 
        /// <summary>
        /// The class addSiteAccount will search for siteid
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>

        public static string jsonresp { get; set; }
        public static string addSiteAccount(Provider loginForm)
        {
            string mn = "addSiteAccount( " + loginForm.ToString() + " )";
            string loginFormJson = JsonConvert.SerializeObject(loginForm);
            string addSiteURL = LoginApp.localURLVer1 + "providers/v1/" + loginForm.getProvider()[0].Id;
            List<string> headers = new List<string>();
               string usersessionid = LoginApp.usession;
               string cbrandsessionid = LoginApp.cbsession;
               headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            string jsonResponse = HTTP.doPut(addSiteURL, loginFormJson, headers);
            jsonresp = jsonResponse;
            return jsonResponse;
        }

        /// <summary>
        /// The following api provides refresh status of an account which was aggregated from the previous api call - AddSiteAccount.addSiteAccount(Provider loginForm)
        /// 
        /// </summary>
        /// <param name="siteAccountId">
        /// @return </param>
        /// <exception cref="IOException"> </exception>
        /// <exception cref="URISyntaxException"> </exception>

       
        public static string getRefreshStatus(long? siteAccountId)
        {
            string mn = "getRefreshStatus( " + siteAccountId.ToString() + " )";
            //Console.WriteLine(fqcn + " :: " + mn);
            string getRefreshStatusURL = LoginApp.localURLVer1 + "refresh/v1/" + siteAccountId.ToString();
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            return HTTP.doGet(getRefreshStatusURL, headers);
        }
        public static void addSiteAccount()
        {
            Provider provider = new Provider();

            Console.WriteLine("AddSiteAccountAPP - TEST - START");
            //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
            //LoginApp.doLogin("private-sandboxtwo", "Yodlee@123", "logademo1", "yodlee@123");
            Console.WriteLine("Enter the site you want to search : ");
            string searchString = Console.ReadLine();
            SiteApp.searchSite(searchString);
            Console.WriteLine("Enter the site Id : ");
            string site = Console.ReadLine();
            provider = SiteApp.getSiteLoginForm(site);
            provider.getProvider()[0].LoginForm.Row[0].Field[0].Value = "DBmet1.site16441.1";
            provider.getProvider()[0].LoginForm.Row[1].Field[0].Value = "site16441.1";
            AddSiteAccount.addSiteAccount(provider);
            siteaccountId siteaccount = JsonConvert.DeserializeObject<siteaccountId>(jsonresp);
            Console.WriteLine(AddSiteAccount.getRefreshStatus(siteaccount.siteAccountId));
            LoginApp.readValue();
        }
     
        public static void Main(string[] args)
        {
            addSiteAccount();
        }
    }
}