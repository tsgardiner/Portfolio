using LanguageApp.Database;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp
{
    public class AppDatabaseTesting : ContentPage
    {

        public AppDatabaseTesting()
        {
            MobileDB mdb = new MobileDB();
            DBGeneric dbg = new DBGeneric();            

            string jsonString = "Ahhhh this didn't change";

            List<WordRecord> add = AddList();
            List<WordRecord> update = UpdateList();
            List<WordRecord> delete = DeleteList();

            Button button = new Button
            {
                Text = String.Format("Get Json")
            };


            Label label = new Label
            {
                Text = jsonString,

                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            button.Clicked += async (sender, e) =>
            {

                Label lb = new Label { Text = jsonString };

                //Repository<WordRecord> wrep = new Repository<WordRecord>(con);

                label.Text = "Button Pressed...Waiting";

                //await wrep.SaveList(wordList);
                //List<WordRecord> temp = await wrep.Find(predicate: x => x.id < 100);
                //await mdb.SaveModelList(add);
                //await mdb.SaveModelList(update);
                //await mdb.DeleteModelList(delete);

                string date = await mdb.LastUpdatedDate();
                Debug.WriteLine(date);

                List<WordRecord> temp = await dbg.GetAll<WordRecord>();
                jsonString = temp[0].word;

                foreach (WordRecord w in temp)
                {
                    Debug.WriteLine(w.id + " = " + w.word);
                }

                //label.Text = jsonString;
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                    label
                }
            };            
        }

        public List<WordRecord> AddList()
        {
            List<WordRecord> list = new List<WordRecord>();
            WordRecord a = new WordRecord();
            a.id = 5;
            a.word = "Powerade";
            WordRecord b = new WordRecord();
            b.id = 88;
            b.word = "Xero";
            list.Add(a);
            list.Add(b);
            return list;
        }

        public List<WordRecord> UpdateList()
        {
            List<WordRecord> list = new List<WordRecord>();
            WordRecord a = new WordRecord();
            a.id = 34;
            a.word = "Testing";
            WordRecord b = new WordRecord();
            b.id = 108;
            b.word = "Cavs - Nation";
            list.Add(a);
            list.Add(b);
            return list;
        }

        public List<WordRecord> DeleteList()
        {
            List<WordRecord> list = new List<WordRecord>();
            WordRecord a = new WordRecord();
            a.id = 34;
            a.word = "Testing";

            list.Add(a);
            return list;
        }






    }
}
