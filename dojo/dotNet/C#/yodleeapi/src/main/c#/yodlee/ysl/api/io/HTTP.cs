using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
namespace yodlee.ysl.api.io
{


    public class HTTP
    {
       
        public static readonly string fqcn = typeof(HTTP).FullName;
        public const string userAgent = "Mozilla/5.0";
        public const string contentTypeURLENCODED = "application/x-www-form-urlencoded";
        public const string contentTypeJSON = "application/json";

        public static string responseCode { get; set; }
        public static string _jsonResponse { get; set; }


        

        public static string doPostUser(string url, List<string> headers, string requestBody, string queryParam)
        {
            if (queryParam != null)
            {
                url = url + "?" + queryParam;
            }
            Uri restURL = new Uri(url);
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(restURL);
            conn.Method = "POST";
            conn.ContentType = contentTypeJSON;
            if (headers != null && headers.Count > 0)
            {
                for (int i = 0; i < headers.Count; i++)
                {
                    conn.Headers.Add(headers[i]);
                }

            }
            using (Stream webStream = conn.GetRequestStream())
            if(requestBody!=null)
            {
                using (StreamWriter requestWriter = new StreamWriter(webStream))
                {
                     requestWriter.Write(requestBody);
                    requestWriter.Close();
                }
            }
            try
            {
                WebResponse webResponse = conn.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {

                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            responseCode = responseReader.ReadToEnd();

                        }

                    }

                }

                String jsonResponse = responseCode;
                return jsonResponse.ToString();
            }
            catch (WebException e) {
                Console.WriteLine(e.Response);
                return null;
            }
                
        }

        public static string doPutNew(string url, List<string> headers, string requestBody)
        {
            string mn = "doIO(PUT : " + url + ", " + requestBody + "sessionTokens : " + headers[0] + " )";
            Uri restURL = new Uri(url);
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(restURL);
            conn.Method = "PUT";
            conn.ContentType = "application/json";
            if (headers != null && headers.Count > 0)
            {
                for (int i = 0; i < headers.Count; i++)
                {
                    conn.Headers.Add(headers[i]);
                }

            }
            using (Stream webStream = conn.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream))
            {
                requestWriter.Write(requestBody);
                requestWriter.Close();
            }
            try
            {
                WebResponse webResponse = conn.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {

                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            responseCode = responseReader.ReadToEnd();

                        }

                    }

                }

                String jsonResponse = responseCode;
                return jsonResponse.ToString();
            }
            catch (WebException)
            {
                return null;
            }

        }




        
       public static string doGet(string url, List<string> headers)
       
    {
          // string mn = "doIO(GET :" + url + ", sessionTokens =  " + headers[0].ToString() + " )";
           
            Uri myURL = new Uri(url);
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(myURL);
            if (headers != null && headers.Count > 0)
            {


                for (int i = 0; i < headers.Count; i++)
                {
                    conn.Headers.Add(headers[i]);
                }

            }

            WebResponse webResponse = conn.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {

                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        responseCode = responseReader.ReadToEnd();

                    }

                }

            }
            
            String jsonResponse = responseCode;
           
            return jsonResponse.ToString();

        }


       public static string doPut(string url, List<string> headers, string requestBody)
       {
           string mn = "doIO(POST : " + url + ", " + requestBody + "sessionTokens : " + headers[0] + " )";
           url = url + "?" + requestBody;
           Uri restURL = new Uri(url);
           HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(restURL);
           conn.Method = "PUT";
           conn.ContentType = "application/json";
           if (headers != null && headers.Count > 0)
           {
               for (int i = 0; i < headers.Count; i++)
               {
                   conn.Headers.Add(headers[i]);
               }

           }
           //using (Stream webStream = conn.GetRequestStream())
           //using (StreamWriter requestWriter = new StreamWriter(webStream))
           //{
           //    requestWriter.Write(requestBody);
           //    requestWriter.Close();
           //}
           try
           {
               WebResponse webResponse = conn.GetResponse();
               using (Stream webStream = webResponse.GetResponseStream())
               {

                   if (webStream != null)
                   {
                       using (StreamReader responseReader = new StreamReader(webStream))
                       {
                           responseCode = responseReader.ReadToEnd();

                       }

                   }

               }

               String jsonResponse = responseCode;
               return jsonResponse.ToString();
           }
           catch (WebException)
           {
               return null;
           }

       }



       public static string doPost(string url, string param, List<string> headers)
        {
            string mn = "doIO(PUT :" + url + ", sessionTokens =  " + headers.ToString() + " )";
         
            string processedURL = url;
            Uri myURL = new Uri(processedURL);
           
            HttpWebRequest conn = (HttpWebRequest)WebRequest.Create(myURL);
            conn.Method = "POST";
            //conn.ContentType = contentTypeURLENCODED;
           
            using (Stream webStream = conn.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream))
            {
                requestWriter.Write(param);
                requestWriter.Close();
            }
         
            if (headers != null && headers.Count > 0)
            {


                for (int i = 0; i < headers.Count; i++)
                {
                    conn.Headers.Add(headers[i]);
                }

            }
            try
            {
                WebResponse webResponse = conn.GetResponse();
            
                using (Stream webStream = webResponse.GetResponseStream())
                {

                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            responseCode = responseReader.ReadToEnd();

                        }

                    }

                }
                }
            catch (WebException e) {
                Console.WriteLine("This program is expected to throw WebException on successful run." +
                       "\n\nException Message :" + e.Message);
                Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
            }
          
            
            string jsonResponse = responseCode;
          
           
            return jsonResponse.ToString();
        }

      

    

    }
}
