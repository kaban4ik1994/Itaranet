using System.Collections.Generic;

namespace itakanet.Interfaces.Api
{
    public interface IApi
    {
        string Get(string url, IDictionary<string, string> parameters);

        string Post<TModel>(string url, TModel model, string cookie);

        string GetPostCookie<TModel>(string url, TModel model);
    }
}
