using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageApp.Database;
using Xamarin.Forms;
using System.Diagnostics;

namespace LanguageApp
{

    /// <summary>
    /// This screen is to test the async connection to the external api
    /// It GETS and displays the database data in json format on the app screen.
    /// </summary>
    public class AppAsyncTestingPage : ContentPage
    {
        public AppAsyncTestingPage()
        {
            string jsonString = "Ahhhh this didn't change";

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
                DatabaseManager dbm = new DatabaseManager();
                label.Text = "Button Pressed...Waiting";

                jsonString = await dbm.CallApi();

                label.Text = jsonString;     
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
    }
}
