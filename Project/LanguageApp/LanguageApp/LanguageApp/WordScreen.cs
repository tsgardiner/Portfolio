using LanguageApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp
{
    public class WordPage : ContentPage
    {
        public WordPage(WordRecord word)
        {


            var padding = new Thickness(0, Device.OnPlatform(40, 40, 0), 0, 0);

            Label wordLabel = new Label
            {
                Text = word.word,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var stackLayout = new StackLayout
            {
                Children = { wordLabel }

            };
            Padding = padding;
            this.Content = stackLayout;
        }


    }
}
