using aybPaymentSolutionApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
    public class MenuBackOfficeVM
    {
        public Command RedirectCommand { get; set; }
        public INavigation navigation { get; set; }

        public MenuBackOfficeVM()
        {
            RedirectCommand = new Command<string>(doRedirect);
        }

        private void doRedirect(string tipo)
        {
            if (tipo.ToString() == "Reg")
            {
                navigation.PushModalAsync(new ListUsers());
            }
            else if (tipo.ToString() == "EM")
            {
                navigation.PushAsync(new ListUsers(), true);
            }
            else if (tipo.ToString() == "MBM")
            {
                //Redirecciona hacia la pantalla del Menu para las opciones de Menus
                navigation.PushAsync(new MenuBackMenu());
            }
        }

    }
}
