using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database.Models
{
    /// <summary>
    ///     Abstract class that all database models inherit from
    /// </summary>
    public abstract class Model
    {
        public string GetTableName()
        {
            return this.GetType().Name;
        }
    }


}
