using aybPaymentSolutionApp.Controllers;
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
	public partial class AccordionPrb : ContentPage
	{
		public AccordionPrb ()
		{
			InitializeComponent ();
		}

        private void ListViewItem_Tabbed(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as ContentListExpandable;
            var vm = BindingContext as MainListView;
            vm?.ShoworHiddenProducts(product);
        }
    }
}