namespace itakanet.Interfaces.Writers
{
    using System.Collections.Generic;

    using itakanet.Models;

    public interface ICsvWriter
    {
        void SaveToFile(IList<CommonDataModel> models);
    }
}
