using LanguageApp.Database;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Classes
{
    public class SplashScreenCS : ContentPage
    {
        private AppManager appManager;

        public SplashScreenCS()
        {
            //BackgroundImage = "ira_on_black.jpg";

            //appManager = new AppManager();

            //Task.Run(() => AsyncCall()).Wait();        

            Button button = new Button { Text = "Splash screen placeholder" };


            button.Clicked += async (sender, e) =>
             {
                 DatabaseManager dbm = new DatabaseManager();
                 MobileDB mobliedb = new MobileDB();
                 DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();
                 appManager = new AppManager();
                 await dbm.CallApi();
                 List<WordPair> wordPairs = await mobliedb.GetAllWordPairs();
                 List<WordRecord> wordRecords = await mobliedb.GetAllWordRecords();

                 List<WordPageCS> wordPageList = new List<WordPageCS>();

                 List<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);

                 await Navigation.PushModalAsync(new MainPageCS(appManager, displayObjects));

             };

            var stackLayout = new StackLayout
            {
                Children = { button },
                Padding = new Thickness(0, 200, 0 , 0)
            };
            this.Content = stackLayout;
        }

        public async Task AsyncCall()
        {
            DatabaseManager dbm = new DatabaseManager();
            MobileDB mobliedb = new MobileDB();
            DisplayObjectMaker displayObjectMaker = new DisplayObjectMaker();

            await dbm.CallApi();
            List<WordPair> wordPairs = await mobliedb.GetAllWordPairs();
            List<WordRecord> wordRecords = await mobliedb.GetAllWordRecords();
            
            List<WordPageCS> wordPageList = new List<WordPageCS>();

            List<DisplayObject> displayObjects = displayObjectMaker.CreateDisplayObjects(wordPairs, wordRecords);
            
            await Navigation.PushModalAsync(new MainPageCS(appManager, displayObjects));
        }




    }
}
