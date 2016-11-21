using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace yodlee.ysl.api.io
{


    public class HTTPS
    {

        //JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
        public static readonly string fqcn = typeof(HTTP).FullName;
        public const string userAgent = "Mozilla/5.0";
        public const string contentTypeURLENCODED = "application/x-www-form-urlencoded";
        public const string contentTypeJSON = "application/json";

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public static String doPost(String url,String requestBody) throws java.io.IOException
        public static string doPost(string url, string requestBody)
        {
            string mn = "doIO(POST : " + url + ", " + requestBody + " )";
            Console.WriteLine(fqcn + " :: " + mn);
            Uri restURL = new Uri(url);
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(restURL);
            conn.Method = "POST";
            conn.Headers["User-Agent"] = userAgent;
            conn.Headers["Content-Type"] = contentTypeURLENCODED;
           // conn.DoOutput = true;
            BinaryWriter wr = new BinaryWriter(conn.GetRequestStream());
            wr.Write(requestBody);
            wr.Flush();
            wr.Close();
            var responseCode = conn.GetResponse();
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Sending 'HTTP POST' request");
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Response Code : " + responseCode);
            //System.IO.StreamReader @in = new System.IO.StreamReader(conn.InputStream);
            System.IO.StreamReader @in = new System.IO.StreamReader(conn.GetRequestStream());
            string inputLine;
            StringBuilder jsonResponse = new StringBuilder();
            while ((inputLine = @in.ReadLine()) != null)
            {
                jsonResponse.Append(inputLine);
            }
            @in.Close();
            Console.WriteLine(fqcn + " :: " + mn + " : " + jsonResponse.ToString());
            return jsonResponse.ToString();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public static String doPostUser(String url, java.util.Map<String,String> sessionTokens, String requestBody) throws java.io.IOException
        public static string doPostUser(string url, IDictionary<string, string> sessionTokens, string requestBody)
        {
            string mn = "doIO(POST : " + url + ", " + requestBody + "sessionTokens : " + sessionTokens + " )";
            Console.WriteLine(fqcn + " :: " + mn);
            Uri restURL = new Uri(url);
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(restURL);
            conn.Method = "POST";
            conn.Headers["User-Agent"] = userAgent;
            conn.Headers["Content-Type"] = contentTypeURLENCODED;
            conn.Headers["Authorization"] = sessionTokens.ToString();
            //conn.DoOutput = true;
            //DataOutputStream wr = new DataOutputStream(conn.OutputStream);
            BinaryWriter wr = new BinaryWriter(conn.GetRequestStream());
            wr.Write(requestBody);
            wr.Flush();
            wr.Close();
            var responseCode = conn.GetResponse();
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Sending 'HTTP POST' request");
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Response Code : " + responseCode);
           // System.IO.StreamReader @in = new System.IO.StreamReader(conn.InputStream);
            System.IO.StreamReader @in = new System.IO.StreamReader(conn.GetRequestStream());
            string inputLine;
            StringBuilder jsonResponse = new StringBuilder();
            while ((inputLine = @in.ReadLine()) != null)
            {
                jsonResponse.Append(inputLine);
            }
            @in.Close();
            Console.WriteLine(fqcn + " :: " + mn + " : " + jsonResponse.ToString());
            return jsonResponse.ToString();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public static String doGet(String url, java.util.Map<String,String> sessionTokens) throws java.io.IOException, java.net.URISyntaxException
        public static string doGet(string url, IDictionary<string, string> sessionTokens)
        {
            string mn = "doIO(GET :" + url + ", sessionTokens =  " + sessionTokens.ToString() + " )";
            Console.WriteLine(fqcn + " :: " + mn);
            Uri myURL = new Uri(url);
            Console.WriteLine(fqcn + " :: " + mn + ": Request URL=" + url.ToString());
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(myURL);
            //conn.setRequestMethod("GET");
            //conn.setRequestProperty("User-Agent", userAgent);
            //conn.setRequestProperty("Content-Type", contentTypeJSON);
            //conn.setRequestProperty("Accept",);
           // conn.setRequestProperty("Authorization", sessionTokens.ToString());
            //conn.DoOutput = true;
            conn.Headers["User-Agent"] = userAgent;
            //conn.Headers["Content-Type"] = contentTypeURLENCODED;
            conn.Headers["Authorization"] = sessionTokens.ToString();
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Sending 'HTTP GET' request");
            var responseCode = conn.GetResponse();
            Console.WriteLine(fqcn + " :: " + mn + " : " + "Response Code : " + responseCode);
            System.IO.StreamReader @in = new System.IO.StreamReader(conn.GetRequestStream());
            string inputLine;
            StringBuilder jsonResponse = new StringBuilder();
            while ((inputLine = @in.ReadLine()) != null)
            {
                Console.WriteLine(inputLine);
                jsonResponse.Append(inputLine);
            }
            @in.Close();
            Console.WriteLine(fqcn + " :: " + mn + " : " + jsonResponse.ToString());
            return jsonResponse.ToString();
        }
    }
}