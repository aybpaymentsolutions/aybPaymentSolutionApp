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
	public partial class MenuPrincipal : ContentPage
	{
		public MenuPrincipal ()
		{
			InitializeComponent ();
            MenuPrincipalVM menuPrincipalVM = new MenuPrincipalVM();
            menuPrincipalVM.navigation = Navigation;
            this.BackgroundImage = "drawable/fondo.png";
            this.logoCmr.Source = "drawable/logo.png";
            this.BindingContext = menuPrincipalVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}