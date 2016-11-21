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

    using Transactions = yodlee.ysl.api.beans.Transactions;
    using yodlee.ysl.api.beans;

   public class TransactionsParser<T> : Parser<Transactions>
    {
       private String fqcn = typeof(TransactionsParser<T>).FullName;
       //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        
        public Transactions parseJSON(string json)
        {
          //  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)];
            Transactions tr = new Transactions();
            if (json != "{}")
            {
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                List<Transaction> transaction = JsonConvert.DeserializeObject<List<Transaction>>(json);//deserializing json object for transaction.
                tr.transaction = transaction;
            }
       
       
       return tr;
        }


       
    }
}