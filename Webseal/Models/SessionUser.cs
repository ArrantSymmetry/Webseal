using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Reflection;
using System.Web;
using LeadsManager.Models;
using Webseal.Util;
using Webseal.Util.StringManipulation;
using Newtonsoft.Json;

namespace Webseal
{

    public static class SessionUser
    {
        private static HttpContext _context;

        public static void SetContext(HttpContext context)
        {
            SessionUser._context = context;
        }

        public static string ConvertToJson()
        {
            try
            {
                FieldInfo[] fields = typeof(SessionUser).GetFields(BindingFlags.Static | BindingFlags.Public);
                object[,] a = new object[fields.Length, 2];
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    a[i, 0] = field.Name;
                    a[i, 1] = field.GetValue(null);
                    i++;
                };
                
                return JsonConvert.SerializeObject(a);
               
            }
            catch
            {
                return null;
                //log err
            }
        }

        public static string UserName
        {
            get
            {
                if (_context.Session["USER_NAME"] is null)
                    return null;
                else
                    return _context.Session["USER_NAME"].ToString();
            }
            set => _context.Session["USER_NAME"] = value;
        }

        public static int? UserId
        {
            get
            {
                if (_context.Session["UserID"] is null)
                    return null;
                else
                    return Convert.ToInt32(_context.Session["UserID"]);
            }
            set => _context.Session["UserID"] = value;
        }

        public static string MudUserId
        {
            get
            {
                if (_context.Session["MUD_USERID"] is null)
                    return null;
                else
                    return _context.Session["MUD_USERID"].ToString();
            }
            set => _context.Session["MUD_USERID"] = value;
        }

        public static int? ProxyId
        {
            get
            {
                if (_context.Session["PROXY_CODE"] is null)
                    return null;
                return Convert.ToInt32(_context.Session["PROXY_CODE"]);
            }
            set => _context.Session["PROXY_CODE"] = value;
        }

        public static int? UserType
        {
            get
            {
                if (_context.Session["USER_Type"] is null)
                    return null;
                else
                    return Convert.ToInt32(_context.Session["USER_Type"].ToString());
            }
            set => _context.Session["USER_Type"] = value;
        }

        public static string UserRole
        {
            get
            {
                if (_context.Session["USER_STRUCTURE"] is null)
                    return null;
                return _context.Session["USER_STRUCTURE"].ToString();
            }
            set => _context.Session["USER_STRUCTURE"] = value;
        }

        public static string UserProvince
        {
            get
            {
                if (_context.Session["USER_PROV"] is null)
                    return null;
                return _context.Session["USER_PROV"].ToString();
            }
            set => _context.Session["USER_PROV"] = value;
        }

        public static DateTime? FromDate
        {
            get
            {
                if (_context.Session["FROM_DATE"] is null)
                    return FormatRules.ParseDate(_context.Session["FROM_DATE"].ToString());
                return null;
            }
            set => _context.Session["FROM_DATE"] = FormatRules.GetDateFormatedProxy(value);
        }

        public static DateTime? ToDate
        {
            get
            {
                if (_context.Session["TO_DATE"] is null)
                    return null;
                return FormatRules.ParseDate(_context.Session["TO_DATE"].ToString());
            }
            set => _context.Session["TO_DATE"] = FormatRules.GetDateFormatedProxy(value);
        }


        public static string UserTitle
        {
            get
            {
                if (_context.Session["USER_TITLE"] is null)
                    return null;
                return _context.Session["USER_TITLE"].ToString();
            }
            set => _context.Session["USER_TITLE"] = value;
        }

        public static string HasProxies
        {
            get
            {
                if (_context.Session["HAS_PROXIES"] is null)
                    return null;
                return _context.Session["HAS_PROXIES"].ToString() == "1" ? "1" : "";

            }
            set => _context.Session["HAS_PROXIES"] = value;
        }


        public static bool? IsProxy
        {
            get
            {
                if (_context.Session["IS_PROXY"] is null)
                    return null;
                return _context.Session["IS_PROXY"].ToString() == "1" ? true : false;

            }
            set => _context.Session["IS_PROXY"] = value;
        }

        public static bool? IsMudUser
        {
            get
            {
                if (_context.Session["IsMudUser"] is null)
                    return null;
                return _context.Session["IsMudUser"].ToString() == "1" ? true : false;

            }
            set => _context.Session["IsMudUser"] = value;
        }


        /// <summary>
        /// User region
        /// </summary>
        public static string UserBranch
        {
            get
            {
                if (_context.Session["USER_REGION"] is null)
                    return null;
                return _context.Session["USER_REGION"].ToString();
            }
            set => _context.Session["USER_REGION"] = value;
        }


        /// <summary>
        /// User branch
        /// </summary>
        public static string UserRegion
        {
            get
            {
                if (_context.Session["UserRegion"] is null)
                    return null;
                return _context.Session["USER_BRANCH"].ToString();
            }
            set => _context.Session["USER_BRANCH"] = value;
        }

        public static string StatusCode
        {
            get
            {
                if (_context.Session["StatusCode"] is null)
                    return null;
                return _context.Session["StatusCode"].ToString();
            }
            set => _context.Session["StatusCode"] = value;
        }

        /// <summary>
        /// User decrypted value
        /// </summary>
        public static string UserDecryptedValue
        {
            get
            {
                if (_context.Session["UserDecryptedValue"] is null)
                    return string.Empty;
                else
                    return _context.Session["UserDecryptedValue"].ToString();
            }
            set => _context.Session["UserDecryptedValue"] = value;
        }

        private static void ClearSession()
        {
            SessionUser.UserName = null;
            SessionUser.UserRole = null;
            SessionUser.UserTitle = null;
            SessionUser.UserProvince = null;
            SessionUser.UserRegion = null;
            SessionUser.UserBranch = null;
            SessionUser.UserType = null;
            SessionUser.ProxyId = null;

        }
    }
}

      