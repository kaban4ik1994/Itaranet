using itakanet.Helpers;
using itakanet.Interfaces.Api;
using itakanet.Interfaces.Services;
using itakanet.Models;

namespace itakanet.Data.Services
{
    public class ItakanetSevice : IItakanetService
    {
        private readonly IApi _api;

        private string Cookie { get; set; }

        public ItakanetSevice(IApi api)
        {
            _api = api;
        }

        public void Logon(LogOnModel model)
        {
            Cookie = _api.GetPostCookie(ConfigHelper.LogOnUrl, model);
        }
    }
}
