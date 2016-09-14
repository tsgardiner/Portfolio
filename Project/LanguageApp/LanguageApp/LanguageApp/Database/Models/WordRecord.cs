using System;
using SQLite;

namespace LanguageApp.Database.Models
{
    [Table("WordRecord")]
    public class WordRecord : IModel
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int id { get; set; }
        public string word { get; set; }
        public string language { get; set; }
        public string description { get; set; }
        public DateTime dateUpdate { get; set; }
        public DateTime dateCreated { get; set; }
        public bool publish { get; set; }

        
    }
}
