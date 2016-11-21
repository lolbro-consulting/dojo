using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using yodlee.ysl.api.beans;

namespace yodlee.ysl.api.parsers
{

    public class ParserFactory
    {
       
        public static readonly string fqcn = typeof(ParserFactory).FullName;

        public static object getParser<T>(Type x,string json) 
        {
            
            string mn = "getParser(" + x + ")";
           
            Parser<T> parser=null;
            
            if (x.FullName.Equals("yodlee.ysl.api.beans.CobrandContext"))
            {
                parser = (CobrandContextParser<T>)new CobrandContextParser<T>() as Parser<T>;
            }
           
            if (x.FullName.Equals("yodlee.ysl.api.beans.UserContext"))
            {
                parser = (UserContextParser<T>)new UserContextParser<T>() as Parser<T>;
            }
           
            if (x.FullName.Equals("yodlee.ysl.api.beans.Accounts"))
            {

                parser = (AccountsParser<T>) new AccountsParser<T>() as Parser<T>;
                       
            }
           
            if (x.FullName.Equals("yodlee.ysl.api.beans.Transactions"))
            {
                parser = (TransactionsParser<T>)new TransactionsParser<T>() as Parser<T>;
            }
           
            if (x.FullName.Equals("yodlee.ysl.api.beans.Bills"))
            {
                parser = (BillsParser<T>)new BillsParser<T>() as Parser<T>;
            }
          
            if (x.FullName.Equals("yodlee.ysl.api.beans.Holdings"))
            {
              parser = (HoldingsParser<T>) new HoldingsParser<T>() as Parser<T>;
            }
           
           if (x.FullName.Equals("yodlee.ysl.api.beans.Providers"))
            {
                parser = (ProvidersParser<T>)new ProvidersParser<T>() as Parser<T>;
            }
           
            if (x.FullName.Equals("yodlee.ysl.api.beans.Provider"))
            {
                parser = (SiteParser<T>)new SiteParser<T>() as Parser<T>;
            }
            if (x.FullName.Equals("yodlee.ysl.api.beans.RefreshStatus"))
            {
                parser = (RefreshStatusParser<T>)new RefreshStatusParser<T>() as Parser<T>;
            }
            if (x.FullName.Equals("yodlee.ysl.api.beans.AssetSummaries"))
            {
                parser = (AssetSummariesParser<T>)new AssetSummariesParser<T>() as Parser<T>;
            }
            if (x.FullName.Equals("yodlee.ysl.api.beans.ProviderAccount"))
            {
                parser = (ProviderAccountParser<T>)new ProviderAccountParser<T>() as Parser<T>;
            }

         
            return parser.parseJSON(json);
            
        }

       


        
    }
}