namespace itakanet.Interfaces.Parsers
{
    using itakanet.Models;

    public interface IExtendedDataParser
    {
        ExtendedDataModel Parse(string htmpData);
    }
}
