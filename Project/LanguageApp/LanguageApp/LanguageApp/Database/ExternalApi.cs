
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class ExternalApi
    {
        //Request data from the backend via httprequest / api call.

        public ExternalApi()
        {

        }

        /// <summary>
        /// Establishes a connection with the external api
        /// Gets a web response and then coverts that web response into a string in json format.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        /// </summary>
        /// <param name="apiString"></param>
        /// <returns></returns>
        public async Task<string> GetJsonData(String apiString)
        {                                  
            try
            {    
                Uri uri = new Uri(apiString);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);  
               
                using (WebResponse response = await request.GetResponseAsync())
                {
                    string jsonString = await ReadWebResponse(response);
                    return jsonString; 
                }   
            }
            catch (WebException we)
            {
                //Not sure if Debug.WriteLine works as replacement for Console.WL.
                Debug.WriteLine("Web Exception:" + we.ToString()); 
                throw;   
            }
        }


        public async Task<string> ReadWebResponse(WebResponse response)
        {  
           return await new StreamReader(response.GetResponseStream()).ReadToEndAsync();             
        }

    }
}
