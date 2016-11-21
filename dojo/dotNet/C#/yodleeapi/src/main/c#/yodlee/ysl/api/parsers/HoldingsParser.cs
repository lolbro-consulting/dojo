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

    using Holdings = yodlee.ysl.api.beans.Holdings;
    using yodlee.ysl.api.beans;

      public class HoldingsParser<T> : Parser<Holdings>
    {
        public string fqcn = typeof(HoldingsParser<T>).FullName;


    
        public  Holdings parseJSON(string json)
       
        {

            Holdings h = new Holdings();
            string mn = "parseJSON(" + json + ")";
           // Console.WriteLine(fqcn + " :: " + mn);
            try
            {
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                List<Holding> holding = JsonConvert.DeserializeObject<List<Holding>>(json);//deserialing the json object for holding.

                h.holding = holding;
               
            }
            catch(ArgumentOutOfRangeException){
                return h;
            }
            return h;
        
            
        }
    }
}