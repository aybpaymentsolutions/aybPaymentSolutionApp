using System;
using System.Collections.Generic;
using System.Text;

namespace aybPaymentSolutionApp.Model
{
    using Newtonsoft.Json;
    using SQLite;

    class CategoryResponse
    {
        
        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("infoCategory")]
        public List<InfoCategory> InfoCategory { get; set; }
    }

    public partial class InfoCategory
    {
        [PrimaryKey]
        [JsonProperty("MenuCategoryID")]
        public int MenuCategoryID { get; set; }

        [JsonProperty("MenuCategoryText")]
        public string MenuCategoryText { get; set; }

        [JsonProperty("MenuCategoryInActive")]
        public bool MenuCategoryInActive { get; set; }

        [JsonProperty("StoreID")]
        public string StoreID { get; set; }
    }

}
