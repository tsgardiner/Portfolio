using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database.Models
{
    public class RootObject
    {        
        public List<WordRecord> WordRecord { get; set; }
        public List<object> Sound { get; set; } //This will need updating when the Models are built
        public List<object> SoundPair { get; set; } //This will need updating when the Models are built
        public List<WordPair> WordPair { get; set; }
    }
}
