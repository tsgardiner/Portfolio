using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{

    public class ApiQueryBuilder
    {

        //Create the api queries for the async call.
        //darvja1
        //jacksct1
        private string apiAddress = "http://gardits1.pythonanywhere.com/";
        private string apiwordRecords = "wordRecords/";

        public ApiQueryBuilder()
        {

        }
           
        public string GetUpdateAllString()
        {
            return apiAddress + apiwordRecords;
        }            
            


        //  YYYY-MM-DDTHH:MM:SS ///SQLite date format    
        /// <JsonDateCoverter>
        /// Covert SQlite string into DateTime so it can then be coverted into json string date format later.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public DateTime StringDateCoverter(String date)
        {
            throw new NotImplementedException();
        }
    }


    
}
