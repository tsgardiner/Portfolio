using SQLite;
using SQLiteNetExtensions.Attributes;

namespace LanguageApp.Database.Models
{
    [Table("WordPair")]
    public class WordPair : IModel
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int id { get; set; }

        [ForeignKey(typeof(WordRecord))]
        public int original { get; set; }

        [ForeignKey(typeof(WordRecord))]
        public int translation { get; set; }

    }
}
