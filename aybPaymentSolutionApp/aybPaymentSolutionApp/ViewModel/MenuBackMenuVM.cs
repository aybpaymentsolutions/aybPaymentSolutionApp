using aybPaymentSolutionApp.View.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
	public class MenuBackMenuVM
	{

        public Command RedirectCommand { get; set; }
        public INavigation navigation { get; set; }

		public MenuBackMenuVM ()
		{
            RedirectCommand = new Command<string>(doRedirect);
		}


        private void doRedirect(string opcionMenu)
        {
            switch (opcionMenu.ToString())
            {
                case "RegCat":
                    navigation.PushModalAsync(new CategoriesMenuList());
                    break;
            }

        }
	}
}