using System.Collections.Generic;

using itakanet.Helpers;
using itakanet.Interfaces.Api;
using itakanet.Interfaces.Services;
using itakanet.Models;

namespace itakanet.Data.Services
{
    public class ItakanetSevice : IItakanetService
    {
        private readonly IApi _api;


        public ItakanetSevice(IApi api)
        {
            _api = api;
        }

        public void Logon(LogOnModel model)
        {
            _api.SetPostCookie(ConfigHelper.LogOnUrl, model);
        }

        public string GetBookingList(BookingCommonDataModel model)
        {
            var result = _api.Post(ConfigHelper.BookingCommonDataUrl, model);
            return result;
        }

        public string GetBookingDetail(string id)
        {
            var result = _api.Get(
                ConfigHelper.BookingDetailUrl,
                new Dictionary<string, string> { { "tourop", ConfigHelper.Tourop }, { "id", id } });
            return result;
        }
    }
}
