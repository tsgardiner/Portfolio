using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Classes
{
    public class DisplayObject
    {
        public int index { get; }  // Not needed
        public string orginal { get; }
        public string translation { get; }
        public string description { get; }
        // Language ??
        // sound properties

        public DisplayObject(int index, string orginal, string translation, string description)
        {
            this.index = index;
            this.orginal = orginal;
            this.translation = translation;
            this.description = description;
        }

    }
}
