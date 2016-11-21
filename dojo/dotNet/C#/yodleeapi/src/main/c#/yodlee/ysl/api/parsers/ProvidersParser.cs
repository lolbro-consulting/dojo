using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;


namespace yodlee.ysl.api.parsers
{
    using Providers = yodlee.ysl.api.beans.Providers;
    using JsonArray = System.Json.JsonArray;
    using JsonElement = System.Json.JsonElement;
    using JsonParser = System.Json.JsonObject;
    using yodlee.ysl.api.beans;
   
    public class ProvidersParser<T> : Parser<Providers>
    {
        public string fqcn = typeof(ProvidersParser<T>).FullName;
      
        public Providers parseJSON(string json)
        {
            string mn = "parseJSON(" + json + ")";
            Providers pr = new Providers();
            try
            {
                //Console.WriteLine(fqcn + " :: " + mn);
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                Provider[] providr = JsonConvert.DeserializeObject<Provider[]>(json);

                pr.provider = providr;
            }
            catch (ArgumentOutOfRangeException) {
                return pr;
            }
           //return null;   
           return pr;
           
        }
    
    }
}