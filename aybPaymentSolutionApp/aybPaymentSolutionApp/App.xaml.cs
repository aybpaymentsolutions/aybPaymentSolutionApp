using aybPaymentSolutionApp.Data;
using aybPaymentSolutionApp.Services;
using Plugin.Connectivity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace aybPaymentSolutionApp
{
	public partial class App : Application
	{
        private static LoginDataBase database;
        public static LoginDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LoginDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("aybdb.db3"));
                }
                return database;
            }
        }

        public static bool isConnected { get; set; }

		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new StartUp());

        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            isConnected = CrossConnectivity.Current.IsConnected;
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        
    }
}
