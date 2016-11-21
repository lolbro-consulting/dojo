using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace yodlee.ysl.api.parsers
{
    using Bills = yodlee.ysl.api.beans.Bills;
    using yodlee.ysl.api.beans;
    class BillsParser<T> : Parser<Bills>
    {
           public String fqcn = typeof(BillsParser<T>).FullName;

                public Bills parseJSON(String json)

                {

            String mn = "parseJSON(" + json + ")";
            Bills bi = new Bills();
           //Console.WriteLine(fqcn + " :: " + mn);
            try
            {
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                List<Bill> bill = JsonConvert.DeserializeObject<List<Bill>>(json);//deserializing the json object for bill class.
                bi.bill = bill;
            }
                  catch(ArgumentOutOfRangeException){
                        return bi;
                    }
            
            
            return bi;
                               

                }

    }
}
