using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace yodlee.ysl.api.parsers
{

    using Accounts = yodlee.ysl.api.beans.Accounts;
    using yodlee.ysl.api.beans;
    using Newtonsoft.Json.Linq;
    public class AccountsParser<T> : Parser<Accounts>
    {
        private String fqcn = typeof(AccountsParser<T>).FullName;
       

        public Accounts parseJSON(string json) 
        {
            string mn = "parseJSON(" + json + ")";
            Accounts a = new Accounts();
            if (json == "{}")
                return a;
            try
            {
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                List<Account> account = JsonConvert.DeserializeObject<List<Account>>(json);//deserializing the values for Account app.

                a.account = account;
            }

            catch(ArgumentOutOfRangeException)
            {
               
            }
            return a;

        }

    }
}