using Newtonsoft.Json;

namespace itakanet.Models
{
    public class LogOnModel
    {
        [JsonProperty("User")]
        public string UserName { get; set; }
        [JsonProperty("Pass")]
        public string Password { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("log_form")]
        public string LogForm { get; set; }
        [JsonProperty("pass_forgotten")]
        public string PassForgotten { get; set; }
    }
}
