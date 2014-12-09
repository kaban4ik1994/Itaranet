using System.Collections.Generic;

using itakanet.Models;

namespace itakanet.Interfaces.Api
{
    public interface IApi
    {
        string Get(string url, IDictionary<string, string> parameters);

        string Post(string url, BookingCommonDataModel model);

        void SetPostCookie(string url, LogOnModel model);


    }
}
