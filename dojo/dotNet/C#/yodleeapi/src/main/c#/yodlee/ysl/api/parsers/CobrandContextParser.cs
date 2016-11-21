using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace yodlee.ysl.api.parsers
{
   
    using CobrandContext = yodlee.ysl.api.beans.CobrandContext;

    public class CobrandContextParser<T> : Parser<CobrandContext>
    {
        

        public string fqcn = typeof(CobrandContextParser<T>).FullName;

       
        public CobrandContext parseJSON(string json)
     
        {
           
            string mn = "parseJSON(" + json + ")";
           // Console.WriteLine(fqcn + " :: " + mn);
             
            CobrandContext cobrandcntxt = JsonConvert.DeserializeObject<CobrandContext>(json);
            return cobrandcntxt;


        }

    }
}
