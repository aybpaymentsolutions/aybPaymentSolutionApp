using aybPaymentSolutionApp.Model;
using aybPaymentSolutionApp.View;
using aybPaymentSolutionApp.ViewModel;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.DeviceInfo;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using aybPaymentSolutionApp.Data;

namespace aybPaymentSolutionApp
{
	public partial class MainPage : ContentPage
	{
        string iddevice = CrossDeviceInfo.Current.Id;
        private LoginViewModel logModel;

        public IList<InfoUser> Friends { get; set; }
        public InfoUser objUser = new InfoUser();


        public MainPage()
		{
			InitializeComponent();
            this.BackgroundImage = "drawable/fondo.png";
            this.logoCmr.Source = "drawable/logo.png";
            logModel = new LoginViewModel();
            this.BindingContext = logModel;
        }

        private void digitCode(object sender, EventArgs e)
        {
            string txtBtn = (sender as Button).Text;
            if (txtBtn == "CLEAR")
            {
                this.txtPin.Text = "";
                this.lblPin.Text = "";
            } else if (txtBtn == "ENTER")
            {
                var consumed = consumeApi(this.txtPin.Text);
                if (consumed.ResponseCode == "000")
                {
                    var settings = new AppSettings();
                    settings.doLogin(consumed.InfoUser, this.Navigation);
                } else if (consumed.ResponseCode == "002")
                {
                    this.txtPin.Text = "";
                    this.lblPin.Text = "";
                    DisplayAlert("Info", "User doesn't exist or wrong pin", "Try again");
                }
            } else
            {
                this.txtPin.Text += txtBtn;
                this.lblPin.Text += "*";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            this.lblLicence.Text = "Register Key: " + iddevice;
        }


        public LoginResponse consumeApi(string pincode)
        {
            var objUserResponse = new LoginResponse();

            if (App.isConnected)
            {
                Task<LoginResponse> task = Task.Run<LoginResponse>(async () => await doLogin(iddevice, pincode));
                if (task.Result.ResponseCode == "000")
                {
                    bool exist = consumeSqlite(pincode, task.Result.InfoUser.userID);
                    Task<int> saveRegister = Task.Run(async () => await saveSqlite(task.Result.InfoUser, exist));
                }
                objUserResponse = task.Result;

            } else
            {
                LoginResponse objResponse = new LoginResponse();
                bool exist = consumeSqlite(pincode, 0);
                if (exist)
                {
                    objResponse.ResponseCode = "000";
                    objResponse.InfoUser = objUser;

                } else
                {
                    objResponse.ResponseCode = "002";
                }
                objUserResponse = objResponse;

            }

            return objUserResponse;
        }


        public async Task<LoginResponse> doLogin(string deviceID, string pinCode)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppSettings.urlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetAsync("/api/Login/" + deviceID + "/" + pinCode);

                    return JsonConvert.DeserializeObject<LoginResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                LoginResponse objResponse = new LoginResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error consuming api: " + ex.Message;
                return objResponse;
            }
        }


        public bool consumeSqlite(string pincode, int iduser) 
        {
            if (iduser == 0)
            {
                Task.Run(async () => objUser = await App.Database.getItemAsync(pincode, iddevice)).Wait();
            } else
            {
                Task.Run(async () => objUser = await App.Database.getItembyId(iduser)).Wait();
            }

            if (objUser != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<int> saveSqlite(InfoUser user, bool exist)
        {
            int guardado = await App.Database.SaveUserAsync(user, exist);
            return guardado;
        }

    }
}
