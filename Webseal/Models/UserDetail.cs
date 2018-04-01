using System;

namespace LeadsManager.Models
{
    public partial class UserDetail
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProxyId { get; set; }
        public string ProxyType { get; set; }
        public string MudId { get; set; }
        public bool? HasProxies { get; set; }
        public bool? IsProxy { get; set; }
        public int? ProxyCount;
        public bool? IsMudUser;
        public int? UserTitleId { get; set; }
        public string UserRole { get; set; }
        public string Province { get; set; }
        public string Region { get; set; }
        public string Branch { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string UserTitle { get; set; }
        
        public int? UserIdType { get; set; }

    }
}
