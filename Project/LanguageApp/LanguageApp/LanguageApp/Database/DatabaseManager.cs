using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class DatabaseManager
    {
        //Handle connections and commuication between each class. 

        ApiQueryBuilder apiQueryBuilder;
        ExternalApi externalAsync;
        JsonParser jsonParser;
        MobileDB mobileDB;        
      
        public string accountKey; //Will be needed eventually to access the api.    
        public string apiAddress;               
        public WebResponse webResponse; //Response returned from te External Async class.

        /// <summary>
        /// 
        /// </summary>
        public DatabaseManager()
        {
            apiQueryBuilder = new ApiQueryBuilder();
            externalAsync = new ExternalApi();
            jsonParser = new JsonParser();
            mobileDB = new MobileDB();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> CallApi()
        {
            apiAddress = apiQueryBuilder.GetUpdateAllString(); 
            Task<string> jsonTask = externalAsync.GetJsonData(apiAddress);
            RootObject root = jsonParser.JsonDeserializer(await jsonTask);
            await SaveAllRecords(root);
            return await jsonTask; //Just for screen printing 
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        public async Task SaveAllRecords(RootObject ro)
        {
            await mobileDB.SaveModelList(ro.WordRecord);
            await mobileDB.SaveModelList(ro.WordPair);
        }

        



    }
}
