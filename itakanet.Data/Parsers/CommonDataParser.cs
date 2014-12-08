using itakanet.Interfaces.Parsers;
using itakanet.Models;

namespace itakanet.Data.Parsers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CommonDataParser : ICommonDataParser
    {
        public CommonDataModel Parse(string htmlData)
        {
            return new CommonDataModel
                       {
                           ReservationNumber = this.GetReservationNumber(htmlData)
                       };
        }

        protected string GetReservationNumber(string htmlData)
        {
            htmlData = htmlData.Replace('\n', ' ');
            StreamWriter writer = new StreamWriter("1.txt");
            writer.Write(htmlData);
            writer.Close();
            Regex pattern = new Regex(@"(crmPersons.*)<table.*<\/table>");
            var array = pattern.Match(htmlData).Value;
            pattern = new Regex(@"<table.*<\/table>");
            array = pattern.Match(array).Value;
            pattern = new Regex(@"<tr>.*<\/tr>");
            var list = (from Match m in pattern.Matches(array) select m.Value).ToList();
            return null;
        }
    }
}
