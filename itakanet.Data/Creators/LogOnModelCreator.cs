using Helpers;
using itakanet.Interfaces.Creators;
using itakanet.Models;

namespace itakanet.Data.Creators
{
    public class LogOnModelCreator : ILogOnModelCreator
    {
        public LogOnModel CreateLogOnModel()
        {
            return new LogOnModel
            {
                Language = ConfigHelper.Language,
                LogForm = ConfigHelper.LogForm,
                PassForgotten = ConfigHelper.PassForgotten,
                Password = ConfigHelper.Password,
                UserName = ConfigHelper.UserName
            };
        }
    }
}
