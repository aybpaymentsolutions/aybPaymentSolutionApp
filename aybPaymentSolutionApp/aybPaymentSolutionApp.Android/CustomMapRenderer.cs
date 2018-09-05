using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using aybPaymentSolutionApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomMapRenderer))]
namespace aybPaymentSolutionApp.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class CustomMapRenderer : NavigationPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
            .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(this);
            bar.SetLogo(Resource.Drawable.icon_short);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}