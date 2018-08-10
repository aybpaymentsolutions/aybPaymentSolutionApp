using Newtonsoft.Json;
using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace aybPaymentSolutionApp.Model
{
    class ListUsersModel
    {
        public ListUsersModel()
        {

        }

        public List<InfoUser> getUsers()
        {

            List<InfoUser> infoUsers = new List<InfoUser>();

            Task<UsersResponse> task = Task.Run<UsersResponse>(async () => await consumeApi());

            if (task.Result.ResponseCode == "000")
            {
                infoUsers = task.Result.InfoUser;
            } else
            {
                infoUsers = null;
            }


            return infoUsers;
        }


        public async Task<UsersResponse> consumeApi()
        {
            try
            {
                string iddevice = CrossDeviceInfo.Current.Id;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppSettings.urlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetAsync("/api/Users/" + iddevice);

                    return JsonConvert.DeserializeObject<UsersResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                UsersResponse objResponse = new UsersResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error consuming api: " + ex.Message;
                return objResponse;
            }
        }

    }
}
