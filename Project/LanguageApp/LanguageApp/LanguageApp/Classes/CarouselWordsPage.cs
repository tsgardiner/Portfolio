using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class CarouselWordsPage : MultiPage<DisplayPage>
    {
        public CarouselWordsPage()
        {

        }

        protected override DisplayPage CreateDefault(object item)
        {
            return new DisplayPage(new DisplayObject(0, "", "", ""));
        }

    }
}
