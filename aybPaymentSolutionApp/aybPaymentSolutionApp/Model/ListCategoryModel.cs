using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using System.Net.Http.Headers;

namespace aybPaymentSolutionApp.Model
{
    class ListCategoryModel
    {
        public ListCategoryModel()
        {

        }

        public List<InfoCategory> GetCategories()
        {
            List<InfoCategory> infoCategories = new List<InfoCategory>();

            Task<CategoryResponse> task = Task.Run<CategoryResponse>(async () => await consumenApi());

            if (task.Result.ResponseCode == "000")
            {
                infoCategories = task.Result.InfoCategory;
            }
            else
            {
                infoCategories = null;
            }

            return infoCategories;
        }


        public async Task<CategoryResponse> consumenApi()
        {
            try
            {
                string idStore = Application.Current.Properties["storeID"].ToString();
                using (var Client = new HttpClient())
                {
                    Client.BaseAddress = new Uri(AppSettings.urlWebApi);
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await Client.GetAsync("/api/Categories/" + idStore);

                    return JsonConvert.DeserializeObject<CategoryResponse>(await result.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                CategoryResponse objResponse = new CategoryResponse();
                objResponse.ResponseCode = "001";
                objResponse.ResponseMessage = "Error consuming Api: " + ex.Message;
                return objResponse;
            }
        }
    }
}
