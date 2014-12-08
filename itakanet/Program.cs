using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using itakanet.Data.Api;
using itakanet.Data.Creators;
using itakanet.Data.Services;
using itakanet.Helpers;

namespace itakanet
{
    class Program
    {
        static void Main()
        {
            var service = new ItakanetSevice(new ItakanetApi());
            var logOnModelCreator = new LogOnModelCreator();
            var bookingCommonDataModelCreator = new BookingCommonDataModelCreator();

            service.Logon(logOnModelCreator.CreateLogOnModel());
            var aa = service.GetBookingList(bookingCommonDataModelCreator.CreateBookingCommonDataModel());
            service.GetBookingDetail(7095216);





            using (var client = new HttpClient())
            {
               // client.BaseAddress = new Uri(ConfigHelper.LogOnUrl);
                var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("log_form", "1"),
                new KeyValuePair<string, string>("User", "sungro"),
                new KeyValuePair<string, string>("Pass", "12298"),
                new KeyValuePair<string, string>("language", "PL"),
                new KeyValuePair<string, string>("pass_forgotten", "")
            });
                var result = client.PostAsync(ConfigHelper.LogOnUrl, content).Result;
                var cook = result.Headers.GetValues("Set-Cookie");
                Console.WriteLine(cook);
                string resultContent = result.Content.ReadAsStringAsync().Result;
             //   Console.WriteLine(resultContent);
               // Console.ReadLine();

                result = client.PostAsync(ConfigHelper.BookingCommonDataUrl, Httpco).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
                Console.ReadLine();
            }
        }
    }
}
