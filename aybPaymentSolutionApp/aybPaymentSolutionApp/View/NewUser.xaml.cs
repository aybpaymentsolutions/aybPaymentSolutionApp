//using Android.Views;
using aybPaymentSolutionApp.Model;
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
	public partial class NewUser : ContentPage
	{

        public List<Option> listOptions { get; set; }


        public NewUser ()
		{
			InitializeComponent ();
            this.BindingContext = new NewUserVM(this);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Black;
            this.Title = Application.Current.Properties["storeName"].ToString();

        }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await ShowMessage("Info", "User Created", "Ok", async () =>
            {
                await Navigation.PopAsync();
            });

        }

        public async Task ShowMessage(string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }

        private void NextMoves()
        {

            Entry entryFName = stackPersonal.FindByName<Entry>("txtFname");
            Entry entryLName = stackPersonal.FindByName<Entry>("txtFname");

            entryFName.Completed += (Object sender, EventArgs e) =>
            {
                entryLName.Focus();
            };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker pickPermission = (sender as Picker);
            Profile currentProfile = (pickPermission.SelectedItem as Profile);

            this.stackTbOptions.Children.Clear();

            TableView tbOptions = new TableView()
            {
                Intent = TableIntent.Form
            };

            TableRoot tRoot = new TableRoot();

            UpdateUserModel objUserModel = new UpdateUserModel();
            List<Option> optionsList = objUserModel.getOptions(Int32.Parse(currentProfile.ProfileId.ToString()));


            var grid = new Grid();
            var rowCount = 0;


            if (optionsList != null)
            {
                foreach (Option rowModule in optionsList)
                {
                    var lblModule = new Label()
                    {
                        FontAttributes = FontAttributes.Bold,
                        Text = rowModule.ModuleName,
                        TextColor = Color.Black
                    };

                    grid.Children.Add(lblModule, 0, rowCount);

                    foreach (OptionsList rowOption in rowModule.OptionsList)
                    {
                        rowCount++;
                        var lblOption = new Label()
                        {
                            Text = " - " + rowOption.OptionText,
                            TextColor = Color.Black
                        };

                        grid.Children.Add(lblOption, 0, rowCount);
                    }
                }
            }

            var viewOptions = new ViewCell()
            {
                View = grid
            };


            var headerTemplate = new DataTemplate();
            

            ListView listvOptions = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = headerTemplate
            };

            this.stackTbOptions.Children.Add(listvOptions);

            //DisplayAlert("Pruebita", currentProfile.ProfileId.ToString(), "OK");
        }

        public void buildForm()
        {

        }
    }
}