using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database.Models
{
    [Table("Modification")]
    public class Modification : IModel
    {
        [SQLite.Net.Attributes.PrimaryKey]
        public int id { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
