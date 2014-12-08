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
            throw new System.NotImplementedException();
        }

        public string Post<TModel>(string url, TModel model, string cookie)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                return result.IsSuccessStatusCode ? result.Content.ReadAsStringAsync().Result : null;
            }
        }

        public string GetPostCookie<TModel>(string url, TModel model)
        {
            using (var client = new HttpClient())
            {
                var result =
                    client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")).Result;
                return result.Headers.GetValues("Set-cookie").First();
            }
        }
    }
}
