using aybPaymentSolutionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aybPaymentSolutionApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartUp : ContentPage
	{
		public StartUp ()
		{
			InitializeComponent ();

            Device.StartTimer(TimeSpan.FromMilliseconds(5000), () =>
            {
                Navigation.PushAsync(new MainPage());
                return false;
            });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}