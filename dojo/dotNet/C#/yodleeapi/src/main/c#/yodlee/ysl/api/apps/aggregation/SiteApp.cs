using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace yodlee.ysl.api.aggregation
{


    using Providers = yodlee.ysl.api.beans.Providers;
    using Site = yodlee.ysl.api.beans.Site;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using GSONParser = yodlee.ysl.api.parsers.GSONParser;
    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using yodlee.ysl.api.beans;

    public class SiteApp
    {
        private static readonly string fqcn = typeof(SiteApp).FullName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param> Site Name i.e dag
        public static void searchSite(string searchString)
        {
            string mn = "searchSite(searchString " + searchString + " )";
            //Console.WriteLine(fqcn + " :: " + mn);
            string searchSiteURL = LoginApp.localURLVer1 + "providers/v1?name=" + searchString;
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            
            string jsonResponse = HTTP.doGet(searchSiteURL,headers);//headers-Authorization headers
           
            Type providertype = typeof(Providers);
            Providers providerList = (Providers)GSONParser.handleJson(jsonResponse, providertype);
            Providers prrovider= new Providers();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Provider Id  Provider Name");
            Console.WriteLine("--------------------------");
          for (int i = 0; i < providerList.pro.Count; i++)//deserialized json response for showing tabular format .
          {
             Console.WriteLine(providerList.pro[i].providerId+" "+ ">>" +" "+ providerList.pro[i].providerName);
          }
          Console.WriteLine("----------------------------");
        }


        public static Provider getSiteLoginForm(string sitId)//id to be searched from list of siteid 
        {
            string mn = "searchSite(site Id " + sitId + " )";
            //Console.WriteLine(fqcn + " :: " + mn);
            string userLoginURL = LoginApp.localURLVer1 + "providers/v1/" + sitId;
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            string jsonResponse = HTTP.doGet(userLoginURL, headers);
            Type sitetype = typeof(Provider);
            Provider site = (Provider)GSONParser.handleJson(jsonResponse, sitetype);
            //Site siteaccount = JsonConvert.DeserializeObject<Site>(jsonResponse);
          Console.WriteLine("The Site Name Is"+site.provider[0].Name);
            return site;
        }
        public static void siteApp()
        {

            Console.WriteLine("SiteAPP - TEST - START");
            //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
            Console.WriteLine("Enter the site you want to search : ");
            string searchString = Console.ReadLine();
            searchSite(searchString);
            Console.WriteLine("Enter the site Id : ");
            string site = Console.ReadLine();
            getSiteLoginForm(site);
            LoginApp.readValue();
        }
        public static void Main(string[] args)
        {
            siteApp();
        }
    }
}