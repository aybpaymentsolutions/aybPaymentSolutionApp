﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aybPaymentSolutionApp.View.Orders
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Orders : ContentPage
	{
		public Orders ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}