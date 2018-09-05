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
	public partial class UpdateUser : ContentPage
	{

		public UpdateUser (InfoUser infoUser = null)
		{
			InitializeComponent ();
            this.BindingContext = new UpdateUserVM(infoUser.userID, this);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Delete", "You want to delete this user?", "Ok", "Cancel");
            if (res) {
                await DisplayAlert("Info", "Can't connect with Web api, please contact technical support", "OK");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await ShowMessage("Info", "InfoUser is null, can't save a null reference, please contact Technical Support", "Ok", async () =>
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