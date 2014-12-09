using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using itakanet.Helpers;
using itakanet.Interfaces.Api;
using itakanet.Models;

using Newtonsoft.Json;

namespace itakanet.Data.Api
{
    public class ItakanetApi : IApi
    {
        private readonly HttpClient _client;

        public ItakanetApi()
        {
            _client=new HttpClient();
        }

        public string Get(string url, IDictionary<string, string> parameters)
        {
            var resultUrl = url+"?";
            resultUrl = parameters.Aggregate(resultUrl, (current, parameter) => current + (parameter.Key + '=' + parameter.Value + '&'));
            
            var result =
                    _client.GetStringAsync(resultUrl).Result;
                return result;
        }
        

        public string Post(string url, BookingCommonDataModel model)
        {
            var content =
                new FormUrlEncodedContent(
                    new[]
                        {
                            new KeyValuePair<string, string>("agencyFilter", model.AgencyFilter),
                            new KeyValuePair<string, string>("archival", model.Archival),
                            new KeyValuePair<string, string>("dateFrom", model.DateFrom),
                            new KeyValuePair<string, string>("dateSet", model.DateSet),
                            new KeyValuePair<string, string>("dateTo", model.DateTo),
                            new KeyValuePair<string, string>("desc", model.Desc),
                            new KeyValuePair<string, string>("oper_type", model.OperType),
                            new KeyValuePair<string, string>("orderby", model.Orderby),
                            new KeyValuePair<string, string>("pagecnt", model.Pagecnt),
                            new KeyValuePair<string, string>("search_by", model.SearchBy),
                            new KeyValuePair<string, string>("search_what", model.SearchWhat),
                            new KeyValuePair<string, string>("show_expedient", model.ShowExpedient),
                            new KeyValuePair<string, string>("show_status", model.ShowStatus)
                        });
            var result = _client.PostAsync(url, content).Result;
            return result.IsSuccessStatusCode ? result.Content.ReadAsStringAsync().Result : null;
        }

        public void SetPostCookie(string url, LogOnModel model)
        {
           
            var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("log_form", model.LogForm),
                new KeyValuePair<string, string>("User", model.UserName),
                new KeyValuePair<string, string>("Pass", model.Password),
                new KeyValuePair<string, string>("language", model.Language),
                new KeyValuePair<string, string>("pass_forgotten", model.PassForgotten)
            });
            var result = _client.PostAsync(ConfigHelper.LogOnUrl, content).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
        }
    }
}
