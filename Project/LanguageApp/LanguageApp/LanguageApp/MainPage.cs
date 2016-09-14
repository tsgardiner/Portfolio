using LanguageApp.Database;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp
{
    public class MainPageCS : CarouselPage
    {
        public MainPageCS()
        {
            //MobileDB mdb = new MobileDB();
            //DBGeneric dbg = new DBGeneric();

            //List<WordRecord> list = new List<WordRecord>();
            //Task.Run(async () => list = await dbg.GetAll<WordRecord>()).Wait();

            //foreach (WordRecord w in list)
            //{
            //    Debug.WriteLine(w.id + " = " + w.word);
            //}
            var padding = new Thickness(0, Device.OnPlatform(40, 40, 0), 0, 0);
            var blueContentPage = new ContentPage
            {
                Padding = padding,
                Content = new StackLayout
                {
                    Children = {
                       new Label {
                           Text = "Swipe Right To View Words -->",
                           FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                           HorizontalOptions = LayoutOptions.Center
                       }
                   }
                }
            };

            this.Children.Add(blueContentPage);

            Task.Run(() => DoAsyncStuff()).Wait();




        }

        public async Task DoAsyncStuff()
        {
            DatabaseManager dbm = new DatabaseManager();
            string jsonString = await dbm.CallApi(); // Doesn't need to return string now.
            DBGeneric dbg = new DBGeneric();
            List<WordRecord> list = new List<WordRecord>();
            list = await dbg.GetAll<WordRecord>();
            foreach (WordRecord w in list)
            {
                this.Children.Add(new WordPage(w));

            }

        }



    }
}
