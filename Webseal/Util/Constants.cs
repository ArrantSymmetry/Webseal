using Webseal.Properties;

namespace Webseal.Util
{
    using Webseal;
    /// <summary>
    /// Api Base URL
    /// </summary>
    public static class Constants
    {
        public const string DateFormat = "dd/MM/yyyy";
        public const string DEFAULT_DROPDOWND_ITME = "---Select---";
        public const string SEARCH = "SEARCH";
        public const string CLEAR = "CLEAR";
        public const string INVALID_MODEL = "Invalid Model";
        public const string SUCCESS = "Success";
        public const string Intermediary = "INT";
        public const string Yes = "Y";
        public const string ProvincialBrokerManager = "PRB";
        public const string ProvincialAdvisorManager = "PRA";
        public const string ProvincialManager = "PRV";
        public const string RegionalMarketingManager = "RMM";
        public const string SalesManager = "SMN";
        public const string BrokerConsultant = "BRC";
        public const string BluestarBusiness = "BSB";
        public const string Broker = "BRO";
        public const string Advisor = "ADV";
        public const string LeadsCoordinationDesk = "LCD";
        public const string TelemarketingAgent = "TEL";
        public const string NoTitle = "OTH";
        public const string SessionExpire = "sessionExpired";
        public const string CalenderCulture = "en-GB";
        public enum UserIdType { User = 1, Proxy = 2, Internal = 3 }

        public static string UrlParam { get; set; } = Resource.urlParam;
    }
 }

