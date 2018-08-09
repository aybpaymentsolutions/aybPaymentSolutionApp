using Android.Views;
using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aybPaymentSolutionApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewUser : ContentPage
	{

        public NewUser ()
		{
			InitializeComponent ();
            this.BindingContext = new NewUserVM(this);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
            this.Title = Application.Current.Properties["storeName"].ToString();

        }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await ShowMessage("Info", "User Created", "Ok", async () =>
            {
                await Navigation.PopAsync();
            });

        }

        public async Task ShowMessage(string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }
    }
}