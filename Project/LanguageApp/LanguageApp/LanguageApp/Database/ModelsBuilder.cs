using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database
{
    public class ModelsBuilder
    {
        public ModelLists modelLists { get; set; }

    }

    public class ModelLists
    {
        public List<WordRecord> wordRecords { get; set; }
        public List<WordPair> wordPairs { get; set; }


          
    }
}
