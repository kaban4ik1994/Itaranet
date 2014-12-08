using itakanet.Data.Api;
using itakanet.Data.Creators;
using itakanet.Data.Services;

namespace itakanet
{
    class Program
    {
        static void Main()
        {
            var service = new ItakanetSevice(new ItakanetApi());
            var creator = new LogOnModelCreator();

            service.Logon(creator.CreateLogOnModel());
        }
    }
}
