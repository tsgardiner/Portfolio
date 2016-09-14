using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class MainPageCS : MasterDetailPage
    {

        public MainPageCS(AppManager appManager, List<DisplayObject> displayObjects)
        {
            Title = "MainPage Using MasterDetailPage";
            string[] myPageNames = { "Home", "Second", "Third" };

            ListView listView = new ListView
            {
                ItemsSource = myPageNames,
            };
            this.Master = new ContentPage
            {
                Title = "Options",
                Content = listView,
                Icon = "ic_menu_black_24dp.png"
            };

            listView.ItemTapped += (sender, e) =>
            {

                Page gotoPage = new Page();
                switch (e.Item.ToString())
                {
                    case "Home":
                        //List<WordRecord> temp = await dbg.GetAll<WordRecord>();
                        //gotoPage = new MainPageCS(displayObjects);
                        //Navigation.PopModalAsync();
                        break;
                }
                //Detail = new NavigationPage(gotoPage);
                ((ListView)sender).SelectedItem = null;
                this.IsPresented = false;
            };

            Detail = new CardCarouselScreenCS(displayObjects);
            IsGestureEnabled = false;

        }


    }
}
