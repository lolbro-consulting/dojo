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
    using Provider = yodlee.ysl.api.beans.Provider;
    using yodlee.ysl.api.beans;
    public class SiteParser<T> : Parser<Provider>
    {
        public string fqcn = typeof(SiteParser<T>).FullName;
        public Provider parseJSON(string json)
        {
            string mn = "parseJSON(" + json + ")";
            //Console.WriteLine(fqcn + " :: " + mn);
            json = json.Substring(json.IndexOf("["));
            json = json.Substring(0, json.LastIndexOf("]") + 1);
            List<Site> prov = JsonConvert.DeserializeObject<List<Site>>(json);//deserialising the value for site class
           // Provider p = new Provider();
           // p.provider = prov;
            return null;
            

        }
    }
}