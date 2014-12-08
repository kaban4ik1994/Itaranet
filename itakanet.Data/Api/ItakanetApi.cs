using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

using itakanet.Helpers;
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

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("merlinX", "t0af22gmbrbvku4k709nja8bi7dhgs22") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_login", ConfigHelper.UserName) { Domain = "test" });
            cookieContainer.Add(new Cookie("login_last_time", "2014-12-08+13%3A46%3A09") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_time", "2014-12-08+13%3A46%3A21") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_agency", "912298001") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_ip", "82.209.219.132") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_sessionid", "ecucqojgqvst0lk1oiucfkaq92ucg1ni") { Domain = "test" });
            cookieContainer.Add(new Cookie("login_start_config", "ITAK") { Domain = "test" });
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler){BaseAddress = new Uri("www.itakanet.pl")})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html,application/xhtml+xml,application/xml",0.9));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp,*/*", 0.8));
                client.DefaultRequestHeaders.AcceptEncoding.Clear();
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip, deflate, sdch"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru-RU,ru",0.8));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US", 0.6));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en", 0.4));
                client.DefaultRequestHeaders.Connection.Clear();
                client.DefaultRequestHeaders.Connection.Add("keep-alive");
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
