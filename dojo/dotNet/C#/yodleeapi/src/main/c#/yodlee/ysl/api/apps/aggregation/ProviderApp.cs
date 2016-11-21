using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using yodlee.ysl.api.apps.yaas;
using yodlee.ysl.api.io;
using yodlee.ysl.api.beans;
using yodlee.ysl.api.parsers;

namespace yodlee.ysl.api.apps.aggregation
{
    public  class ProviderApp
    {
        public static readonly String fqcn = typeof(ProviderApp).FullName;

        public static void searchProvider(String searchString)
        {
            String mn = "searchSite(searchString " + searchString + " )";
            Console.WriteLine(fqcn + " :: " + mn);
            String searchProviderURL = LoginApp.localURLVer1 + "providers?name=" + searchString;
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doGet(searchProviderURL, headers);
            Providers providers = (Providers)GSONParser.handleJson(jsonResponse, typeof(Providers));
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Id  Provider Name        Login Url");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < providers.provider.Length; i++)//deserialized json response for showing tabular format .
            {
                Console.WriteLine(providers.provider[i].id + " " + ">>" + " " + providers.provider[i].name + "  " + ">>" + "  " +providers.provider[i].loginUrl);
            }
            Console.WriteLine("--------------------------------------------------");
            //Console.Write(providers.toString());
        }

        public static Providers getProviderLoginForm(String providerId)
        {
            //Console.WriteLine(fqcn + " :: " + mn);
            String getSiteURL = LoginApp.localURLVer1 + "providers/" + providerId;
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doGet(getSiteURL, headers);
            Providers providers = (Providers)GSONParser.handleJson(jsonResponse, typeof(Providers));
            Console.WriteLine(providers.toString());
            return providers;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("ProviderApp - TEST - START");
            LoginApp.doLogin("yodlee_10000004", "yodlee123", "allcases", "TEST@123");
            //Console con = new Console();
            //if (con != null) {
            Console.WriteLine("Enter the site you want to search : ");
            String searchString = Console.ReadLine();
            //String searchString = con
            //.readLine("Enter the site you want to search : ");
            searchProvider(searchString);
            //}
            //if (con != null) {
            Console.WriteLine("Enter the site Id : ");
            String site = Console.ReadLine();
            getProviderLoginForm(site);
            //}
        }
    }
}
