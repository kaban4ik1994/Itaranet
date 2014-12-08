using Newtonsoft.Json;

namespace itakanet.Models
{
    public class BookingCommonDataModel
    {
        public string AgencyFilter { get; set; }
        
        public string Archival { get; set; }
        
        public string DateFrom { get; set; }
        
        public string DateSet { get; set; }
        
        public string DateTo { get; set; }
        
        public string Desc { get; set; }
        
        public string OperType { get; set; }
        
        public string Orderby { get; set; }

        public string Pagecnt { get; set; }
        
        public string SearchBy { get; set; }
        
        public string SearchWhat { get; set; }
        
        public string ShowExpedient { get; set; }

        public string ShowStatus { get; set; }
    }
}
