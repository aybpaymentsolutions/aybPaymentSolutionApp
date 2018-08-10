using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace aybPaymentSolutionApp.Model
{
    public partial class UserActionResponse
    {
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("idUser")]
        public int IdUser { get; set; }
    }
}
