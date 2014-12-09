namespace itakanet.Data.Parsers
{
    using System.Text.RegularExpressions;

    using itakanet.Interfaces.Parsers;
    using itakanet.Models;

    public class ExtendedDataParser : IExtendedDataParser
    {
        public ExtendedDataModel Parse(string htmpData)
        {
            return new ExtendedDataModel { Provision = this.GetProvisionByHtml(htmpData) };
        }

        protected string GetProvisionByHtml(string htmlData)
        {
            htmlData = htmlData.Replace('\n', ' ');

            var pattern = new Regex(@"<\s*b\s*>\s*Prowizja\s*<\s*\/\s*b\s*>\s*(?<Key1>((?!<\s*\/\s*tr[\s]*>).)*)\s*((?!<\s*\/\s*tr[\s]*>).)*");
            var data = pattern.Match(htmlData).Groups["Key1"].Value;
            pattern = new Regex(@"<\s*b\s*>\s*(?<Key1>[^<]*\w[^<]*)\s*<");
            return pattern.Match(data).Groups["Key1"].Value;
        }
    }
}
