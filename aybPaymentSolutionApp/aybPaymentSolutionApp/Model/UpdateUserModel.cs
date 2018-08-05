using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace aybPaymentSolutionApp.Model
{
    public class UpdateUserModel
    {
        public UpdateUserModel()
        {

        }



        public async Task<UserActionResponse> saveUser(UserInfoResponse user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppSettings.urlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string serializedObject = JsonConvert.SerializeObject(user);
                    HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("/api/Users/saveUser", contentPost);

                    return JsonConvert.DeserializeObject<UserActionResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                UserActionResponse objResponse = new UserActionResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error consuming api: " + ex.Message;
                return objResponse;
            }
        }


        public async Task<UserInfoResponse> consumeUserData(int idUser)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppSettings.urlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.GetAsync("/api/Users/getUserInfo/" + idUser);

                    return JsonConvert.DeserializeObject<UserInfoResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                UserInfoResponse objResponse = new UserInfoResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error consuming api: " + ex.Message;
                return objResponse;
            }
        }


        public UserData getUserData(int idUser)
        {
            UserData infoUser = new UserData();

            Task<UserInfoResponse> task = Task.Run<UserInfoResponse>(async () => await consumeUserData(idUser));

            if (task.Result.ResponseCode == "000")
            {
                infoUser = task.Result.UserData;
            }
            else
            {
                infoUser = null;
            }

            return infoUser;
        }

        public UserActionResponse saveUserData(UserInfoResponse user)
        {
            UserActionResponse actionResponse = new UserActionResponse();
            Task<UserActionResponse> task = Task.Run<UserActionResponse>(async () => await saveUser(user));

            return task.Result;

        }

    }

}
