using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.ViewModel;
using Plugin.Connectivity;
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
	public partial class ListUsers : ContentPage
	{
        public ListUsers ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#1E73BE");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;

            if (this.ToolbarItems.Count == 0)
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    var offnetwork = new ToolbarItem
                    {
                        Icon = "off.png",
                        Order = ToolbarItemOrder.Primary
                    };
                    this.ToolbarItems.Add(offnetwork);
                }

                var adduseritem = new ToolbarItem
                {
                    Icon = "ic_adduser.xml",
                    Command = new Command(async () =>
                    {
                        await Navigation.PushAsync(new NewUser(), true);
                    })
                };
                this.ToolbarItems.Add(adduseritem);
            }

            this.BindingContext = new ListUsersVM();
            ((ListView)this.listUsers).SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                InfoUser currentUser = (e.SelectedItem as InfoUser);
                Navigation.PushAsync(new UpdateUser(currentUser));
            }
        }
    }
}