using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yodlee.ysl.api.apps.pfm
{
    using LoginApp = yodlee.ysl.api.apps.yaas.LoginApp;
    using AssetSummaries = yodlee.ysl.api.beans.AssetSummaries;
    using HTTP = yodlee.ysl.api.io.HTTP;
    using GSONParser = yodlee.ysl.api.parsers.GSONParser;
   
    public class AssetSummaryApp
    {
        private static readonly string fqcn = typeof(AssetSummaryApp).FullName;

        public static AssetSummaries AssetSummaries
        {
            get
            {
                string mn = "getAssetSummaries()";
                //Console.WriteLine(fqcn + " :: " + mn);
                string holdingsURL = LoginApp.localURLVer1 + "derived/holdingSummary?include=details";
                List<string> headers = new List<string>();
                string usersessionid = LoginApp.usession;
                string cbrandsessionid = LoginApp.cbsession;
                headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
               string jsonResponse = HTTP.doGet(holdingsURL,headers);//heades-Authorization headers i.e-member session id and cobrand sesion id.
                //Console.WriteLine(jsonResponse);
                 Type assetSummaryType = typeof(AssetSummaries);
                AssetSummaries assetSummaries = (AssetSummaries)GSONParser.handleJson(jsonResponse,assetSummaryType);
                return assetSummaries;
            }
        }
        public static void assetSummaryApp()
        {
            Console.WriteLine("AssetSummary - TEST - START");

            //LoginApp.doLogin("yodlee_10000004", "yodlee123", "ysluser2", "TEST@123");
            Console.WriteLine("------------------------");
            Console.WriteLine("ClassificationType ClassificationValue Contribution Value HoldingId AccountId Value Cash");
            Console.WriteLine("------------------------");
            AssetSummaries assetSummaries = AssetSummaryApp.AssetSummaries;
            Console.WriteLine(assetSummaries.ToString());
            LoginApp.readValue();
        }
        public static void Main(string[] a)
        {
            assetSummaryApp();
        }

    }
}
