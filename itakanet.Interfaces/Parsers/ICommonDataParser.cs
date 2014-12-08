using itakanet.Models;

namespace itakanet.Interfaces.Parsers
{
    public interface ICommonDataParser
    {
        CommonDataModel Parse(string htmlData);
    }
}
