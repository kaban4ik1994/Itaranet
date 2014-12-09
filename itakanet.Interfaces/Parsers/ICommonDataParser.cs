using itakanet.Models;

namespace itakanet.Interfaces.Parsers
{
    using System.Collections.Generic;

    public interface ICommonDataParser
    {
        IList<CommonDataModel> Parse(string htmlData);
    }
}
