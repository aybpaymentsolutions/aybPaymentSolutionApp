using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace aybPaymentSolutionApp
{
    public class AppSettings
    {

        INavigation navigation;

        public const string sqlserverString = "Server= 184.168.194.77;Database=ABPOSDevdb;User ID=dev;Password=Xzo665y@;Trusted_Connection=False;";
        public const string urlWebApi = "http://96.231.33.87:8589";

        public void doLogin(InfoUser user, INavigation nav)
        {
            Application.Current.Properties["storeName"] = "nikhil@msdn.com";
            Application.Current.Properties["userName"] = user.Fname;
            NavigationPage newNP = new NavigationPage(new MenuPrincipal());
            App.Current.MainPage = newNP;
            nav.PopToRootAsync();
        }

        public void doLogout()
        {
            try
            {

                Application.Current.Properties.Clear();
                NavigationPage newNP = new NavigationPage(new MainPage());
                App.Current.MainPage = newNP;
                navigation.PopToRootAsync();

            } catch (Exception ex)
            {
                var error = ex.Message;
            }
            
        }
    }
}
