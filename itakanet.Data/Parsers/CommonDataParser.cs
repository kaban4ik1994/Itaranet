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
        public IList<CommonDataModel> Parse(string htmlData)
        {
            var htmpDataList = this.GetReservationCellHtmlData(htmlData);
            var result = htmpDataList.Select(this.ParseReservationCellHtmlData).ToList();
            return result;
        }

        protected IList<string> GetReservationCellHtmlData(string htmlData)
        {
            htmlData = htmlData.Replace('\n', ' ');

            var pattern = new Regex(@"<\s*tr[^>]*class=[^>]*>((?!<\s*\/\s*tr[\s]*>).)*<img((?!<\s*\/\s*tr[\s]*>).)*<\s*\/\s*tr[\s]*>");
            return (from Match match in pattern.Matches(htmlData) from Capture capture in match.Captures select capture.Value).ToList();
        }

        protected virtual CommonDataModel ParseReservationCellHtmlData(string htmlData)
        {
            var pattern = new Regex(@"<\s*td[^>]*>((?!<\s*\/\s*td[\s]*>).)*<\s*\/\s*td[\s]*>");
            var list = (from Match match in pattern.Matches(htmlData) from Capture capture in match.Captures select capture.Value).ToList();

            var result = new CommonDataModel
                             {
                                 ReservationNumber = this.ParseReservationNumberByTag(list[1]),
                                 FirstDate = this.ParseFirstDateByTag(list[2]),
                                 SecondDate = this.ParseSecondDateByTag(list[3]),
                                 Name = this.ParseNameByTag(list[4]),
                                 Price = this.ParsePriceByTag(list[5]),
                                 Status = this.ParseStatusByTag(list[6]),
                                 Agent = this.ParseAgentByTag(list[7])
                             };

            return result;
        }

        protected string ParseReservationNumberByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }

        protected string ParseFirstDateByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }

        protected string ParseSecondDateByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }

        protected string ParseNameByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }

        protected string ParsePriceByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }

        protected string ParseStatusByTag(string tag)
        {
            // TODO: Change it
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<"); 
            var data = pattern.Match(tag).Groups["Key1"].Value;
            if (!string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            var pattern2 = new Regex("src=\\s*\\\"(?<Key1>[^\\\"]+)\\s*\\\"");
            return pattern2.Match(tag).Groups["Key1"].Value;
        }

        protected string ParseAgentByTag(string tag)
        {
            var pattern = new Regex(@">\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(tag).Groups["Key1"].Value;
        }
    }
}
