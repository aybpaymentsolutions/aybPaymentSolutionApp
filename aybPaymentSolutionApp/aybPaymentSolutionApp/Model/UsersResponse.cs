using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace aybPaymentSolutionApp.Model
{

    public partial class UsersResponse
    {
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("infoUser")]
        public List<InfoUser> InfoUser { get; set; }
    }
}