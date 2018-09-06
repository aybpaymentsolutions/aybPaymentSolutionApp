using aybPaymentSolutionApp;
using aybPaymentSolutionApp.View;
using aybPaymentSolutionApp.View.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
    public class MenuPrincipalVM
    {
        public Command RedirectCommand { get; set; }
        public INavigation navigation { get; set; }

        public MenuPrincipalVM()
        {
            RedirectCommand = new Command<string>(doRedirect);
        }

        private void doRedirect(string tipo)
        {
            if (tipo.ToString() == "Reg")
            {
                navigation.PushAsync(new Orders(), true);
            } else if (tipo.ToString() == "BO")
            {
                navigation.PushAsync(new MenuBackOffice(), true);
            } else if (tipo.ToString() == "EX")
            {
                var settings = new AppSettings();
                settings.doLogout();
            }
        }
    }
}
