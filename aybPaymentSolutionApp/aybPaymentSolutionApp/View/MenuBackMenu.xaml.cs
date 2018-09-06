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
	public partial class MenuBackMenu : ContentPage
	{
        public MenuBackMenu()
        {
            InitializeComponent();

            this.BackgroundImage = "drawable/fondo.png";
            this.logoCmr.Source = "drawable/logo.png";
            MenuBackMenuVM menuBackMenuVM = new MenuBackMenuVM();
            menuBackMenuVM.navigation = Navigation;
            this.BindingContext = menuBackMenuVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}