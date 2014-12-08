using System.Configuration;

namespace itakanet.Helpers
{
    public class ConfigHelper
    {
        public static string UserName { get { return ConfigurationManager.AppSettings["Username"]; } }
        public static string Password { get { return ConfigurationManager.AppSettings["Password"]; } }
        public static string Language { get { return ConfigurationManager.AppSettings["Language"]; } }
        public static string LogForm { get { return ConfigurationManager.AppSettings["LogForm"]; } }
        public static string PassForgotten { get { return ConfigurationManager.AppSettings["PassForgotten"]; } }
        public static string LogOnUrl { get { return ConfigurationManager.AppSettings["LogOnUrl"]; } }
        public static string BookingCommonDataUrl { get { return ConfigurationManager.AppSettings["BookingCommonDataUrl"]; } }
        public static string AgencyFilter { get { return ConfigurationManager.AppSettings["AgencyFilter"]; } }
        public static string Archival { get { return ConfigurationManager.AppSettings["Archival"]; } }
        public static string DateFrom { get { return ConfigurationManager.AppSettings["DateFrom"]; } }
        public static string DateSet { get { return ConfigurationManager.AppSettings["DateSet"]; } }
        public static string DateTo { get { return ConfigurationManager.AppSettings["DateTo"]; } }
        public static string Desc { get { return ConfigurationManager.AppSettings["Desc"]; } }
        public static string OperType { get { return ConfigurationManager.AppSettings["OperType"]; } }
        public static string Orderby { get { return ConfigurationManager.AppSettings["Orderby"]; } }
        public static string Pagecnt { get { return ConfigurationManager.AppSettings["Pagecnt"]; } }
        public static string SearchBy { get { return ConfigurationManager.AppSettings["SearchBy"]; } }
        public static string SearchWhat { get { return ConfigurationManager.AppSettings["SearchWhat"]; } }
        public static string ShowExpedient { get { return ConfigurationManager.AppSettings["ShowExpedient"]; } }
        public static string ShowStatus { get { return ConfigurationManager.AppSettings["ShowStatus"]; } }
        public static string BookingDetailUrl { get { return ConfigurationManager.AppSettings["BookingDetailUrl"]; } }
        public static string Tourop { get { return ConfigurationManager.AppSettings["Tourop"]; } }
    }
}
