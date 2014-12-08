namespace itakanet.Models
{
    public class CommonDataModel
    {
        public string ReservationNumber { get; set; }
        
        public string FirstDate { get; set; }

        public string SecondDate { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Status { get; set; }

        public string Agent { get; set; }

        public ExtendedDataModel Details { get; set; }
    }
}
