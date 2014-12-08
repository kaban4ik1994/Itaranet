using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using itakanet.Interfaces.Api;
using Newtonsoft.Json;

namespace itakanet.Data.Api
{
    public class ItakanetApi : IApi
    {
        public string Get(string url, IDictionary<string, string> parameters)
        {
            var resultUrl = url+"?";
            resultUrl = parameters.Aggregate(resultUrl, (current, parameter) => current + (parameter.Key + '=' + parameter.Value + '&'));

            using (var client = new HttpClient())
            {
                var result =
                    client.GetStringAsync(resultUrl).Result;
                return result;
            }
        }

        public string Post<TModel>(string url, TModel model, string cookie)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/xhtml+xml")).Result;
                return result.IsSuccessStatusCode ? result.Content.ReadAsStringAsync().Result : null;
            }
        }

        public string GetPostCookie<TModel>(string url, TModel model)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
                return result.Headers.GetValues("Set-Cookie").First();
            }
        }
    }
}
