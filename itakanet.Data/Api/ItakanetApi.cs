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
        

        public string Post<TModel>(string url, TModel model)
        {
                var result =
                    _client.PostAsync(url, new StringContent(model.ToString())).Result;
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
            var cook = result.Headers.GetValues("Set-Cookie");
            Console.WriteLine(cook);
            string resultContent = result.Content.ReadAsStringAsync().Result;
            //   Console.WriteLine(resultContent);
            // Console.ReadLine();

            result = _client.PostAsync(ConfigHelper.BookingCommonDataUrl, new StringContent(new BookingCommonDataModel().ToString())).Result;
            resultContent = result.Content.ReadAsStringAsync().Result;


              //  var result =
              //      _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
              // result = _client.PostAsync(ConfigHelper.BookingCommonDataUrl, new StringContent(new BookingCommonDataModel().ToString())).Result;
              //var aaa = result.Content.ReadAsStringAsync().Result;
              //  string resultContent = result.Content.ReadAsStringAsync().Result;
        }
    }
}
