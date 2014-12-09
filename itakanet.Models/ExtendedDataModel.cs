namespace itakanet.Models
{
    using LINQtoCSV;

    public class ExtendedDataModel
    {
        [CsvColumn(Name = "Provision", FieldIndex = 1)]
        public string Provision { get; set; }

        public override string ToString()
        {
            return this.Provision;
        }
    }
}
