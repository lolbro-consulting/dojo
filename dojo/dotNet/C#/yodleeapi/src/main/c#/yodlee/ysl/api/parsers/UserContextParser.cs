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

    using UserContext = yodlee.ysl.api.beans.UserContext;

    

    public class UserContextParser<T> : Parser<UserContext>
    {



        public string fqcn = typeof(UserContextParser<T>).FullName;
        
        public UserContext parseJSON(string json)
    {
        string mn = "parseJSON(" + json + ")";
        //Console.WriteLine(fqcn + " :: " + mn);
        UserContext usercontextt = JsonConvert.DeserializeObject<UserContext>(json);//deserialising json object for UserContext class
        return usercontextt;

    }

       

        
    }
}