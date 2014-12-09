using itakanet.Data.Api;
using itakanet.Data.Creators;
using itakanet.Data.Services;

namespace itakanet
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using itakanet.Data.Parsers;
    using itakanet.Data.Writers;
    using itakanet.Models;

    class Program
    {
        static void Main()
        {
            var service = new ItakanetSevice(new ItakanetApi());
            var logOnModelCreator = new LogOnModelCreator();
            var bookingCommonDataModelCreator = new BookingCommonDataModelCreator();

            service.Logon(logOnModelCreator.CreateLogOnModel());

            var commonInformation = new List<CommonDataModel>();



            var i = 0;
            while (true)
            {
                string boockingList; 
                try
                {
                    boockingList = service.GetBookingList(bookingCommonDataModelCreator.CreateBookingCommonDataModel(i.ToString(CultureInfo.InvariantCulture)));
                }
                catch (Exception)
                {
                    break;
                }

                var parser = new CommonDataParser();
                var list = parser.Parse(boockingList);

                if (!list.Any())
                {
                    break;
                }

                commonInformation.AddRange(list);
                i++;
                if (i > 100)
                {
                    break;
                }
            }

            foreach (var info in commonInformation)
            {
                var page = service.GetBookingDetail(info.ReservationNumber);
                var parser = new ExtendedDataParser();
                info.ExtendedDataModel = parser.Parse(page);
            }

            var csvWriter = new CsvWriter();
            csvWriter.SaveToFile(commonInformation);
        }
    }
}
