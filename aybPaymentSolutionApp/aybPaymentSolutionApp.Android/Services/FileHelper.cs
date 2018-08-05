using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using aybPaymentSolutionApp.Droid.Services;
using aybPaymentSolutionApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace aybPaymentSolutionApp.Droid.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}