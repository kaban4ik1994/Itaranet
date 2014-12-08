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
            var logOnModelCreator = new LogOnModelCreator();
            var bookingCommonDataModelCreator = new BookingCommonDataModelCreator();

            service.Logon(logOnModelCreator.CreateLogOnModel());
            var boockingList = service.GetBookingList(bookingCommonDataModelCreator.CreateBookingCommonDataModel());
            var boockingDetail = service.GetBookingDetail(7095216);
        }
    }
}
