using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using yodlee.ysl.api.beans;
using Newtonsoft.Json;

namespace yodlee.ysl.api.parsers
{
   

        class ProviderAccountParser<T> : Parser<ProviderAccount>
    {
            public ProviderAccount parseJSON(String json) {
                ProviderAccount providerAccount = JsonConvert.DeserializeObject<ProviderAccount>(json);//deserializing the values for Account app.
                // Accounts a = new Accounts();
                // a.account = account;
                //return a;
                return providerAccount;
            }

    }
}
