namespace itakanet.Data.Writers
{
    using System.Collections.Generic;

    using itakanet.Interfaces.Writers;
    using itakanet.Models;

    using LINQtoCSV;

    public class CsvWriter : ICsvWriter
    {
        public void SaveToFile(IList<CommonDataModel> models)
        {

            var outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',', // tab delimited
                FirstLineHasColumnNames = true, // no column names in first record
                FileCultureName = "ru-RU" // use formats used in The Netherlands
            };
            var cc = new CsvContext();
            cc.Write(models, "Itakanet.csv", outputFileDescription);
        }
    }
} 
