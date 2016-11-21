using System.Collections.Generic;

namespace yodlee.ysl.api.io
{


    public class YodleeHTTPDefaults
    {

        public static IDictionary<string, string> yodleeHTTPDefaults = new Dictionary<string, string>();

        public static void initYodleeHTTPDefaultsMap()
        {
            yodleeHTTPDefaults["User-Agent"] = "Mozilla/5.0";
            yodleeHTTPDefaults["Content-Type"] = "application/x-www-form-urlencoded";
            yodleeHTTPDefaults["Accept"] = "application/json";

        }

        public static IDictionary<string, string> YodleeHTTPDefaultsMap
        {
            get
            {
                return yodleeHTTPDefaults;
            }
        }

    }
}