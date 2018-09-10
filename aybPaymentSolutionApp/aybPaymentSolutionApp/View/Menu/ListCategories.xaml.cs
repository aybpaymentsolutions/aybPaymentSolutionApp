using aybPaymentSolutionApp.ViewModel;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aybPaymentSolutionApp.View.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListCategories : ContentPage
	{
		public ListCategories ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //NavigationPage.SetHasNavigationBar(this, true);

            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;

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

                var addCategory = new ToolbarItem
                {
                    Icon = "ic_adduser.xml",
                    Command = new Command(async () =>
                    {
                        await Navigation.PushAsync(new MenuBackMenu(), true);
                    })
                };
                this.ToolbarItems.Add(addCategory);
            }

            this.BindingContext = new ListCategoriesVM();
            ((ListView)this.listCatMenu).SelectedItem = null;
        }

    }
}