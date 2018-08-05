using aybPaymentSolutionApp.Model;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.ViewModel
{
    public class LoginViewModel
    {

        public Command loginCmd { get; set; }
        public string pinCode { get; set; }

        public LoginViewModel()
        {
            
        }


        public string login()
        {
            string deviceid = CrossDeviceInfo.Current.Id;
            Task<LoginResponse> task = Task.Run<LoginResponse>(async () => await doLogin(deviceid, pinCode));
            return task.Result.ResponseCode;
        }

        public async Task<LoginResponse> doLogin(string deviceID, string pinCode)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55189/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetAsync("/api/Licence/" + deviceID + "/" + pinCode);

                    return JsonConvert.DeserializeObject<LoginResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                LoginResponse objResponse = new LoginResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error al consumir api: " + ex.Message;
                return objResponse;
            }
        }

    }
}
