using itakanet.Models;

namespace itakanet.Interfaces.Services
{
    public interface IItakanetService
    {
        void Logon(LogOnModel model);

        string GetBookingList(BookingCommonDataModel model);

        string GetBookingDetail(string id);

    }
}
