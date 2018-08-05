using aybPaymentSolutionApp.Data;
using aybPaymentSolutionApp.Services;
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

		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new StartUp());

        }

		protected override void OnStart ()
		{   
            // Handle when your app starts
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
