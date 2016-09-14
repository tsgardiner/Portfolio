using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LanguageApp.Droid.DroidClasses;
using Android.Graphics;
using static Java.Util.ResourceBundle;
using Xamarin.Forms.Platform.Android;
using LanguageApp.Classes;

[assembly: ExportRenderer(typeof(WordLabel), typeof(WordLabelRender))]
namespace LanguageApp.Droid.DroidClasses
{
    public class WordLabelRender : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (TextView)Control;
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Lato-Bold.ttf");  // font name specified here
            label.Typeface = font;
        }

    }
}