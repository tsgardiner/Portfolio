using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class DisplayPage : ContentPage
    {
        public DisplayObject DisplayObject;

        public DisplayPage(DisplayObject displayObject)
        {
            DisplayObject = displayObject;
        }


    }
}
