using itakanet.Helpers;
using itakanet.Models;

namespace itakanet.Data.Creators
{
    public class BookingCommonDataModelCreator
    {
        public BookingCommonDataModel CreateBookingCommonDataModel()
        {
            return new BookingCommonDataModel
                       {
                           AgencyFilter = ConfigHelper.AgencyFilter,
                           Archival = ConfigHelper.Archival,
                           DateFrom = ConfigHelper.DateFrom,
                           DateSet = ConfigHelper.DateSet,
                           DateTo = ConfigHelper.DateTo,
                           Desc = ConfigHelper.Desc,
                           OperType = ConfigHelper.OperType,
                           Orderby = ConfigHelper.Orderby,
                           Pagecnt = ConfigHelper.Pagecnt,
                           SearchBy = ConfigHelper.SearchBy,
                           SearchWhat = ConfigHelper.SearchWhat,
                           ShowExpedient = ConfigHelper.ShowExpedient,
                           ShowStatus = ConfigHelper.ShowStatus
                       };
        }
    }
}
