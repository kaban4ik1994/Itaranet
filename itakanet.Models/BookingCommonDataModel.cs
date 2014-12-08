using Newtonsoft.Json;

namespace itakanet.Models
{
    public class BookingCommonDataModel
    {
        [JsonProperty("agencyFilter")]
        public string AgencyFilter { get; set; }
        [JsonProperty("archival")]
        public string Archival { get; set; }
        [JsonProperty("dateFrom")]
        public string DateFrom { get; set; }
        [JsonProperty("dateSet")]
        public string DateSet { get; set; }
        [JsonProperty("dateTo")]
        public string DateTo { get; set; }
        [JsonProperty("desc")]
        public string Desc { get; set; }
        [JsonProperty("oper_type")]
        public string OperType { get; set; }
        [JsonProperty("orderby")]
        public string Orderby { get; set; }
        [JsonProperty("pagecnt")]
        public string Pagecnt { get; set; }
        [JsonProperty("search_by")]
        public string SearchBy { get; set; }
        [JsonProperty("search_what")]
        public string SearchWhat { get; set; }
        [JsonProperty("show_expedient")]
        public string ShowExpedient { get; set; }
        [JsonProperty("show_status")]
        public string ShowStatus { get; set; }
    }
}
