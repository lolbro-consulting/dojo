using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using yodlee.ysl.api.beans;
using Newtonsoft.Json;

namespace yodlee.ysl.api.parsers
{
    class RefreshStatusParser<T> : Parser<RefreshStatus>
    {

       
	public RefreshStatus parseJSON(String json) 
	{
		//String mn = "parseJSON(" + json + ")";
		//System.out.println(fqcn + " :: " + mn);
		//Gson gson = new Gson();
		//return (RefreshStatus)gson.fromJson(json, RefreshStatus.class);
       // json = json.Substring(json.IndexOf("["));
       // json = json.Substring(0, json.LastIndexOf("]") + 1);
        RefreshStatus refreshstatus = JsonConvert.DeserializeObject<RefreshStatus>(json);//deserializing the values for Account app.
       // Accounts a = new Accounts();
       // a.account = account;
        //return a;
        return refreshstatus;
	}
    }
}
