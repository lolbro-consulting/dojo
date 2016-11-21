using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace yodlee.ysl.api.parsers
{
    using AssetSummaries = yodlee.ysl.api.beans.AssetSummaries;
    using yodlee.ysl.api.beans;
    public class AssetSummariesParser<T> : Parser<AssetSummaries>
    {
        public string fqcn = typeof(AssetSummariesParser<T>).FullName;



        public AssetSummaries parseJSON(string json)
        {

            
            AssetSummaries summaries = new AssetSummaries();
            string mn = "parseJSON(" + json + ")";
            // Console.WriteLine(fqcn + " :: " + mn);
            try
            {
                json = json.Substring(json.IndexOf("["));
                json = json.Substring(0, json.LastIndexOf("]") + 1);
                List<AssetSummary> assetSummary = JsonConvert.DeserializeObject<List<AssetSummary>>(json);//deserialing the json object for holding.

                summaries.assetSummary = assetSummary;
            }
            catch (ArgumentOutOfRangeException)
            {
                return summaries;
            }
            return summaries;


        }
    }
}
