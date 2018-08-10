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
	public partial class MenuBackOffice : ContentPage
	{
		public MenuBackOffice ()
		{
			InitializeComponent ();
            this.BackgroundImage = "drawable/fondo.png";
            MenuBackOfficeVM menuBackOfficeVM = new MenuBackOfficeVM();
            menuBackOfficeVM.navigation = Navigation;
            this.logoCmr.Source = "drawable/logo.png";
            this.BindingContext = menuBackOfficeVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}