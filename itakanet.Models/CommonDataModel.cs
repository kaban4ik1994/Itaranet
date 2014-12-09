using LINQtoCSV;

namespace itakanet.Models
{
    public class CommonDataModel
    {

        [CsvColumn(Name = "ReservationNumber", FieldIndex = 1)]
        public string ReservationNumber { get; set; }
        [CsvColumn(Name = "FirstDate", FieldIndex = 2)]
        public string FirstDate { get; set; }
        [CsvColumn(Name = "SecondDate", FieldIndex = 3)]
        public string SecondDate { get; set; }
        [CsvColumn(Name = "Name", FieldIndex = 4)]
        public string Name { get; set; }
        [CsvColumn(Name = "Price", FieldIndex = 5)]
        public string Price { get; set; }
        [CsvColumn(Name = "Status", FieldIndex = 6)]
        public string Status { get; set; }
        [CsvColumn(Name = "Agent", FieldIndex = 7)]
        public string Agent { get; set; }
        [CsvColumn(Name = "Details", FieldIndex = 8)]
        public ExtendedDataModel ExtendedDataModel { get; set; }
    }
}
