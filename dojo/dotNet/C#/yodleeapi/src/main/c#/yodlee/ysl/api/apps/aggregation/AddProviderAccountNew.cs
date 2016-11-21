using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using yodlee.ysl.api.beans;
using yodlee.ysl.api.apps.yaas;
using HTTP = yodlee.ysl.api.io.HTTP;
using yodlee.ysl.api.parsers;
using Newtonsoft.Json.Linq;
using System.IO;

namespace yodlee.ysl.api.apps.aggregation
{
    class AddProviderAccountNew
    {
        private static readonly String fqcn = typeof(AddProviderAccount).FullName;

        public static ProviderAccount addProviderAccount(Providers providers)
        {
            JsonSerializer serialiser = new JsonSerializer();
            serialiser.NullValueHandling = NullValueHandling.Ignore;
            Provider p = providers.getProvider()[0];
            String providerJson = JsonConvert.SerializeObject(p.loginForm, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            providerJson = "{\"loginForm\":" + providerJson;
            providerJson = providerJson.Replace("\r\n", "");
           // providerJson = providerJson.Replace(" ", "");
            providerJson = providerJson + "}";

            string aa = providerJson;
            Console.WriteLine(aa);
            String addSiteURL = LoginApp.localURLVer1 + "providers/providerAccounts?providerId=" + providers.getProvider()[0].getId();
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doPost(addSiteURL, providerJson, headers);
            ProviderAccount providerAccount = (ProviderAccount)GSONParser.handleJson(jsonResponse, typeof(ProviderAccount));
            return providerAccount;
        }
        public static ProviderAccount doChallenge(LoginForm loginForm, String providerAccountId)
        {
            String mn = "doChallenge( " + loginForm.ToString() + " providerAccountId = " + providerAccountId;
            String providerJson = JsonConvert.SerializeObject(loginForm, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            providerJson = providerJson.Replace("\r\n", "");
            providerJson = "{\"loginForm\":" + providerJson + "}";
            Console.WriteLine(providerJson);
            String addSiteURL = LoginApp.localURLVer1 + "providers/providerAccounts?providerAccountIds=" + providerAccountId;
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doPutNew(addSiteURL, headers, providerJson);
            ProviderAccount providerAccount = (ProviderAccount)GSONParser.handleJson(jsonResponse, typeof(ProviderAccount));
            return providerAccount;

        }
        public static ProviderAccount getProviderAccount(String providerAccountId)
        {
         
            String getRefreshStatusURL = LoginApp.localURLVer1 + "providers/providerAccounts/" + providerAccountId.ToString();
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
            string cbrandsessionid = LoginApp.cbsession;
            headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doGet(getRefreshStatusURL, headers);
            // Console.WriteLine(jsonResponse);
            ProviderAccount providerAccount = (ProviderAccount)GSONParser.handleJson(jsonResponse, typeof(ProviderAccount));
            return providerAccount;
        }

        public static ProviderAccount addNonMFA_Account(Providers providers)
        {
            Console.WriteLine(" Add Non_MFA_Account:  ");
            Console.WriteLine("Enter your provider userName : ");
            String userName = Console.ReadLine();//"DBmet1.site16441.1";//
            providers.getProvider()[0].getLoginForm().getRow()[0].getField()[0].setValue(userName);
            Console.WriteLine("Enter provider password : ");
            String password = Console.ReadLine();//"site16441.1";//
            providers.getProvider()[0].getLoginForm().getRow()[1].getField()[0].setValue(password);
            ProviderAccount providerAccount = AddProviderAccountNew.addProviderAccount(providers);
            string refMsg;
            ProviderAccount pAcnt;
            do
            {
                pAcnt = AddProviderAccountNew.getProviderAccount(providerAccount.providerAccount.id);
                refMsg = pAcnt.providerAccount.refreshInfo.status ;
                Console.WriteLine("status" + refMsg + ", additionalStatus " + providerAccount.providerAccount.refreshInfo.additionalStatus);
                if (refMsg == "FAILED")
                {
                    Console.WriteLine("login failed please try again" + refMsg);
                    break;
                }
                
            } while (refMsg != "SUCCESS");
            if (refMsg == "SUCCESS")
                Console.WriteLine("Account added successfully");
            return pAcnt;
        }
        public static void addMFA_Account(Providers providers)
        {


            Console.WriteLine(" Add MFA_Account:  ");
            Console.WriteLine("Enter your provider userName : ");
             String userName = Console.ReadLine();
            providers.getProvider()[0].getLoginForm().getRow()[0].getField()[0].setValue(userName);
            Console.WriteLine("Enter provider password : ");
             String password = Console.ReadLine();
            providers.getProvider()[0].getLoginForm().getRow()[1].getField()[0].setValue(password);
            ProviderAccount providerAccount= AddProviderAccountNew.addProviderAccount(providers);
            string refMsg;
            do
            {
                providerAccount = AddProviderAccountNew.getProviderAccount(providerAccount.providerAccount.id);
                refMsg = providerAccount.providerAccount.refreshInfo.status;
                Console.WriteLine("refresh status" + refMsg);
                if (refMsg == "FAILED")
                {
                    Console.WriteLine("login failed please try again" + refMsg);
                    break;
                }
            } while (providerAccount.providerAccount.getLoginForm() == null);
            //while (refMsg != "FAILED")
            //{
            //    refMsg = providerAccount.providerAccount.refreshInfo.status;
            //    Console.WriteLine("refresh status" + refMsg);
            //    if (refMsg == "FAILED")
            //    {
            //        Console.WriteLine("login failed please try again" + refMsg);
            //        break;
            //    }
            //     providerAccount = AddProviderAccountNew.getProviderAccount(providerAccount.providerAccount.id);
            //}
            if (refMsg != "FAILED")
            {   
                Console.WriteLine("received form:" + providerAccount.providerAccount.getLoginForm());
                providerAccount.providerAccount.getLoginForm().getRow()[0].getField()[0].setValue("123456");
                Console.WriteLine("putting mfa token");
                providerAccount = doChallenge(providerAccount.providerAccount.getLoginForm(), providerAccount.providerAccount.id);

            }
            while (providerAccount.providerAccount.getLoginForm() == null&&refMsg != "FAILED"&&refMsg!="SUCCESS"&&refMsg!="PARTIAL_SUCCESS")
            {
                refMsg = providerAccount.providerAccount.refreshInfo.status;
                Console.WriteLine("refresh status" + refMsg);
                if (refMsg == "FAILED")
                {
                    Console.WriteLine("login failed please try again" + refMsg);
                    break;
                }
                providerAccount = AddProviderAccountNew.getProviderAccount(providerAccount.providerAccount.id);
            }
            if (refMsg != "FAILED" && refMsg != "SUCCESS" && refMsg != "PARTIAL_SUCCESS")
            {
                Console.WriteLine("received form:" + providerAccount.providerAccount.getLoginForm());
                providerAccount.providerAccount.getLoginForm().getRow()[0].getField()[0].setValue("Texas");
                providerAccount.providerAccount.getLoginForm().getRow()[1].getField()[0].setValue("w3schools");
                Console.WriteLine("putting mfa Q&A");
                providerAccount = doChallenge(providerAccount.providerAccount.getLoginForm(), providerAccount.providerAccount.id);
                refMsg = providerAccount.providerAccount.refreshInfo.status;
            }
            while (refMsg != "SUCCESS" && refMsg != "PARTIAL_SUCCESS")
            {
                Console.WriteLine("refresh status" + refMsg + ",additional_Status " + providerAccount.providerAccount.refreshInfo.additionalStatus);
                if (refMsg == "FAILED")
                {
                    Console.WriteLine("login failed please try again" + refMsg);
                    break;
                }
                providerAccount = AddProviderAccountNew.getProviderAccount(providerAccount.providerAccount.id);
                refMsg = providerAccount.providerAccount.refreshInfo.status;
            }
            if(refMsg == "SUCCESS")
            Console.WriteLine("acount aded successfully");
            if (refMsg == "PARTIAL_SUCCESS")
                Console.WriteLine("acount aded partially");
            // Fetch the accounts if you need ! 

        }
        public static void AddAccount(int type)
        {
            Providers providers = null;
            RefreshStatus refreshStatus = null;
            Console.WriteLine("Add Provider Account App - TEST - START");
            Console.WriteLine("Enter the name of the  Provider you want to search : ");
            String searchString = Console.ReadLine();
            //String searchString = "Dag";
            ProviderApp.searchProvider(searchString);
            if (type == 2)
            {
                Console.WriteLine("Enter the Provider Id : ");
                String providerId = Console.ReadLine();
                //String providerId = "16442";
                providers = ProviderApp.getProviderLoginForm(providerId);
                addMFA_Account(providers);
            }
            if (type == 1)
            {
                Console.WriteLine("Enter the Provider Id : ");
                String providerId = Console.ReadLine();
                //String providerId = "16441";
                providers = ProviderApp.getProviderLoginForm(providerId);
                addNonMFA_Account(providers);
            }
            //Console.ReadLine();
            LoginApp.readValue();
        }
        public static void Main(string[] args)
        {


        }

    }
}
