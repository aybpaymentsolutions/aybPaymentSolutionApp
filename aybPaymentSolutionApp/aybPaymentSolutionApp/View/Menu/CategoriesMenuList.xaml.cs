using Plugin.Connectivity;
using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;

namespace aybPaymentSolutionApp.View.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriesMenuList : ContentPage
	{
		public CategoriesMenuList ()
		{
			InitializeComponent ();
		}

        private async void ListView_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            var categoriesMenu = this.listView.BindingContext as CategoriesMenuList;
            if (e.Action == DragAction.Start)
            {
                categoriesMenu.IsVisible = true;
                this.stackLayout.Opacity = 0.25;
            }

            if(e.Action == DragAction.Dragging)
            {
                var position = new Point(e.Position.X - this.listView.Bounds.X, e.Position.Y - this.listView.Bounds.Y);
                if (this.stackLayout.Bounds.Contains(position))
                    this.deleteLabel.TextColor = Color.Red;
                else
                    this.deleteLabel.TextColor = Color.White;
            }

            if(e.Action == DragAction.Drop)
            {
                var position = new Point(e.Position.X - this.listView.Bounds.X, e.Position.Y - this.listView.Bounds.Y);
                if(this.stackLayout.Bounds.Contains(position))
                {
                    //Task.Delay = false;
                    //categoriesMenu.toDoList.Remove(e.ItemData as ToDoItem);
                }
                categoriesMenu.IsVisible = false;
                this.deleteLabel.TextColor = Color.White;
                this.headerLabel.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;

            if(this.ToolbarItems.Count == 0)
            {
                if(!CrossConnectivity.Current.IsConnected)
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
                        await Navigation.PushAsync(new MenuBackOffice(), true);
                    })
                };
                this.ToolbarItems.Add(addCategory);
            }
        }
    }
}