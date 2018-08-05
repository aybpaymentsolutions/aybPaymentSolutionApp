using System;
using System.Collections.Generic;
using System.Text;

namespace aybPaymentSolutionApp.Model
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SQLite;

    public partial class LoginResponse
    {
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("infoUser")]
        public InfoUser InfoUser { get; set; }
    }

    public partial class InfoUser
    {
        [PrimaryKey]
        [JsonProperty("userID")]
        public int userID { get; set; }

        [JsonProperty("fname")]
        public string Fname { get; set; }

        [JsonProperty("pinCode")]
        public string pinCode { get; set; }

        [JsonProperty("deviceID")]
        public string deviceID { get; set; }

        [JsonProperty("rol")]
        public string Rol { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
