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
     class AddProviderAccount
    {
        private static readonly String fqcn = typeof(AddProviderAccount).FullName;

        public static RefreshStatus addProviderAccount(Providers providers)
	   {
		
           JsonSerializer serialiser = new JsonSerializer();
           serialiser.NullValueHandling = NullValueHandling.Ignore;
           
            String providerJson = "{\"provider\":["+ JsonConvert.SerializeObject(providers.getProvider()[0],Formatting.Indented,new JsonSerializerSettings
         
            {
              
              NullValueHandling = NullValueHandling.Ignore,
              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
              
             
             
            });
         
             providerJson = providerJson.Replace("\r\n", "");
             providerJson = providerJson.Replace(" ", "");
             providerJson = providerJson + "]}";
       
            string aa = providerJson;
            Console.WriteLine(aa);
	       	String addSiteURL = LoginApp.localURLVer1 + "providers/"  + providers.getProvider()[0].getId();
    
            List<string> headers = new List<string>();
            string usersessionid = LoginApp.usession;
               string cbrandsessionid = LoginApp.cbsession;
               headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
            String jsonResponse = HTTP.doPost(addSiteURL,providerJson,headers);
		    RefreshStatus refreshStatus = (RefreshStatus) GSONParser.handleJson(jsonResponse, typeof(RefreshStatus));

		    //Console.WriteLine(refreshStatus.ToString());
		    return refreshStatus;
	   }
    public static void doChallenge(LoginForm loginForm, String providerAccountId)
       {
		String mn = "doChallenge( " + loginForm.ToString() + " providerAccountId = " + providerAccountId;
	
		String providerJson =  JsonConvert.SerializeObject(loginForm, Formatting.Indented,new JsonSerializerSettings
         
            {
              
              NullValueHandling = NullValueHandling.Ignore,
              ReferenceLoopHandling = ReferenceLoopHandling.Ignore         
             
            });
        //providerJson = providerJson.Replace("loginForm", "");
       // providerJson = providerJson.Replace("\\",
        providerJson = providerJson.Replace("IsOptional","isOptional");
        providerJson = providerJson.Replace("\r\n", "");
        providerJson = providerJson.Replace(" ", "");
        providerJson = providerJson.Replace("SecurityKey", "Security Key");
        providerJson = providerJson.Replace("Whatisthenameofyourstate?", "What is the name of your state?");
        providerJson = providerJson.Replace("Whatisthenameofyourfirstschool", "What is the name of your first school");
        //providerJson = providerJson.Replace("loginForm","");
        //providerJson = "{\"mfaTimeout\":99940,\"formType\":\"token\",\"row\":[{\"id\":\"token_row\",\"label\":\"Security Key\",\"fieldRowChoice\":\"0001\",\"form\":\"0001\",\"field\":[{\"id\":\"token\",\"name\":\"tokenValue\",\"isOptional\":false,\"value\":\"123456\",\"valueEditable\":\"true\",\"maxLength\":6,\"type\":\"text\"}]}]}";
       providerJson = "{\"loginForm\":" + providerJson + "}";
		Console.WriteLine(providerJson);
		String addSiteURL = LoginApp.localURLVer1 + "providers/"+providerAccountId ;
         List<string> headers = new List<string>();
               string usersessionid = LoginApp.usession;
               string cbrandsessionid = LoginApp.cbsession;
               headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
		String jsonResponse = HTTP.doPut(addSiteURL,headers,"MFAChallenge="+ providerJson);
	  }
     public static RefreshStatus getRefreshStatus(String providerAccountId)
     {
		//String mn = "getRefreshStatus( " + providerAccountId.ToString() + " )";
		//Console.WriteLine(fqcn + " :: " + mn);
		String getRefreshStatusURL = LoginApp.localURLVer1 + "refresh/"+ providerAccountId.ToString();
         List<string> headers = new List<string>();
               string usersessionid = LoginApp.usession;
               string cbrandsessionid = LoginApp.cbsession;
               headers.Add("Authorization:{userSession= " + usersessionid + ",cobSession=" + cbrandsessionid + "}");
		String jsonResponse =  HTTP.doGet(getRefreshStatusURL, headers);
       // Console.WriteLine(jsonResponse);
		RefreshStatus refreshStatus = (RefreshStatus) GSONParser.handleJson(jsonResponse, typeof(RefreshStatus));
		Console.WriteLine(refreshStatus.toString());
		return refreshStatus;
	}
     
public static void getRefreshStatus(RefreshStatus refreshStatus) 
	{
		Console.WriteLine(refreshStatus.toString());
		//Keep Polling this api to get RefreshStatus : 
		for(int i=0; i<10; i++)
		{
			getRefreshStatus(refreshStatus.getProviderAccountId());
		}
	}
public static RefreshStatus addNonMFA_Account(Providers providers) 
	{
        Console.WriteLine(" Add Non_MFA_Account:  ");
        Console.WriteLine("Enter your provider userName : ");
        String userName = Console.ReadLine();
        //String userName = "ysldemo.site16442.1";
        // For internal Yodlee Dag tool use this hardcoded user Name = "DBmet1.site16441.1"
        providers.getProvider()[0].getLoginForm().getRow()[0].getField()[0].setValue(userName);

        Console.WriteLine("Enter provider password : ");
        String password = Console.ReadLine();
        //String password = "site16442.1";
        //String password = con.readLine("Enter provider password : ");
        // For internal Yodlee Dag tool use this hardcoded password = "site16441.1"
        providers.getProvider()[0].getLoginForm().getRow()[1].getField()[0].setValue(password);		
		RefreshStatus refreshStatus = AddProviderAccount.addProviderAccount(providers);
    string refMsg;
    RefreshStatus rstatus;
    do
    {
        rstatus = AddProviderAccount.getRefreshStatus(refreshStatus.providerAccountId);
        //RefreshStatus rstatus = (RefreshStatus)GSONParser.handleJson(jsonResponse, typeof(RefreshStatus));
        refMsg = rstatus.refreshInfo.refreshStatus;
        if (refMsg == "LOGIN_FAILURE" || refMsg == "REFRESH_TIMED_OUT" || refMsg == "REFRESH_CANCELLED" || refMsg=="SITE_CANNOT_BE_REFRESHED")
        {
            Console.WriteLine("login failed please try again" + refMsg);
            break;
        }
        if (refMsg == "REFRESH_COMPLETED_ACCOUNTS_ALREADY_AGGREGATED") {
            Console.WriteLine("Account already added" + refMsg);
            break;
        }
       // Console.WriteLine("login failed please try again" + refMsg);
        // }
    } while (refMsg != "REFRESH_COMPLETED");
    if (refMsg == "REFRESH_COMPLETED")
        Console.WriteLine("Account added successfully");
		return rstatus;
	}
       public static void addMFA_Account(Providers providers) 
	{
		
	
    Console.WriteLine(" Add MFA_Account:  ");
    Console.WriteLine("Enter your provider userName : ");	
   // String userName = Console.ReadLine();
    String userName = "DBmet1.site16442.1";
			// For internal Yodlee Dag tool use this hardcoded user Name = "DBmet1.site16441.1"
			providers.getProvider()[0].getLoginForm().getRow()[0].getField()[0].setValue(userName);
		
           Console.WriteLine("Enter provider password : ");
           // String password = Console.ReadLine();
           String password = "site16442.1";
			//String password = con.readLine("Enter provider password : ");
			// For internal Yodlee Dag tool use this hardcoded password = "site16441.1"
			providers.getProvider()[0].getLoginForm().getRow()[1].getField()[0].setValue(password);	
		RefreshStatus refreshStatus = AddProviderAccount.addProviderAccount(providers);
        string refMsg;
       // RefreshStatus rstatus;
        do
        {
            refreshStatus = AddProviderAccount.getRefreshStatus(refreshStatus.providerAccountId);
            //RefreshStatus rstatus = (RefreshStatus)GSONParser.handleJson(jsonResponse, typeof(RefreshStatus));
            refMsg = refreshStatus.refreshInfo.refreshStatus;
            if (refMsg == "LOGIN_FAILURE" || refMsg == "REFRESH_TIMED_OUT" || refMsg == "REFRESH_CANCELLED" || refMsg == "SITE_CANNOT_BE_REFRESHED")
            {
                Console.WriteLine("login failed please try again" + refMsg);
                break;
            }
            if (refMsg == "REFRESH_COMPLETED_ACCOUNTS_ALREADY_AGGREGATED")
            {
                Console.WriteLine("Account already added" + refMsg);
                break;
            }
            // Console.WriteLine("login failed please try again" + refMsg);
            // }
        } while (refreshStatus.getLoginForm()==null);
		//while(refreshStatus.getLoginForm()==null)
		//{
			//refreshStatus = AddProviderAccount.getRefreshStatus(refreshStatus.providerAccountId);
		//}
        
            refreshStatus.getLoginForm().getRow()[0].getField()[0].setValue("123456");
            doChallenge(refreshStatus.getLoginForm(), refreshStatus.providerAccountId);
            refreshStatus = AddProviderAccount.getRefreshStatus(refreshStatus.getProviderAccountId());
            while (refreshStatus.getLoginForm() == null)
            {
                refreshStatus = AddProviderAccount.getRefreshStatus(refreshStatus.getProviderAccountId());
            }
            refreshStatus.getLoginForm().getRow()[0].getField()[0].setValue("Texas");
            refreshStatus.getLoginForm().getRow()[1].getField()[0].setValue("w3schools");
            doChallenge(refreshStatus.getLoginForm(), refreshStatus.getProviderAccountId());

            while (refMsg != "REFRESH_COMPLETED")
            {
                refreshStatus = AddProviderAccount.getRefreshStatus(refreshStatus.getProviderAccountId());
                refMsg = refreshStatus.refreshInfo.refreshStatus;
            }
            Console.WriteLine("acount aded successfully");
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
