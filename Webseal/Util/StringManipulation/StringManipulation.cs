using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Webseal.Util.StringManipulation
{
   
    public static class FormatRules { 

        /// <summary>
        /// Date format as per Sanlam standard
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static string DateFormatted(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {
                return Convert.ToDateTime(inputDate).ToString("dd/MM/yyyy");
            }
            else
            {
                return string.Empty;
            }
        }

 
        public static string RemoveBlankLines(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.Replace(input, @"\t|\n|\r", " ");
            }
            else
            {
                return string.Empty;
            }
        }

 
        public static string FormatCurrency(long? input)
        {
            if (input != 0)
            {
                if (input != null)
                {
                    string amt = $"{Convert.ToDecimal(input / 100):0 000}";
                    return amt + "," + decimal.Remainder(Convert.ToDecimal(input), 100);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return "0,00";
            }
        }

        public static string GetDateFormatedProxy(DateTime? proxyDate)
        {
            DateTime date = Convert.ToDateTime(proxyDate);
            if (date != null)
            {
                return date.Year.ToString() + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00");
            }
            else
            {
                return string.Empty;
            }
        }

    
        public static string FormatNumber(long? input)
        {
            if (input != null)
            {
                return $"{Convert.ToDecimal(input):0 000}";
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatCurrency(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string amt = $"{(Convert.ToDecimal(input) / 100):0 000}";
                return amt + "," + decimal.Remainder(Convert.ToDecimal(input), 100);
            }
            else
            {
                return string.Empty;
            }
        }

      
        public static string PaddString(long? input, int maxLength)
        {
            if (input != null && input != 0)
            {
                if (input.ToString().Length < maxLength)
                {
                    return input.ToString().PadLeft(maxLength, '0');
                }
                else
                {
                    return input.ToString();
                }

            }
            else
            {
                return string.Empty;
            }
        }

   
        public static string PaddString(string input, int maxLength)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToString().Length < maxLength)
                {
                    return input.ToString().PadLeft(maxLength, '0');
                }
                else
                {
                    return input.ToString();
                }

            }
            else
            {
                return string.Empty;
            }
        }

        public static string DateTimeFormattedDash_yMd_t(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {

                if (inputDate.Length > 15)
                {
                    string date = Convert.ToDateTime(inputDate.Substring(0, 10)).ToString("yyyy-MM-dd");
                    string time = inputDate.Substring(11, 8);
                    return date + " " + time;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string DateTimeFormattedSlash_yMd_time(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {

                if (inputDate.Length > 15)
                {
                    string date = Convert.ToDateTime(inputDate.Substring(0, 10)).ToString("yyyy/MM/dd");
                    string time = inputDate.Substring(11, 8);
                    return date + " " + time;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

         public static string DateFormattedDash_yMd(string inputDate)
        {
            if (!string.IsNullOrEmpty(inputDate))
            {
                return (DateTime.ParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));
            }
            else
            {
                return null;
            }
        }

        public static string GetTellNumber(string cellNo, string workNo, string homeNo)
        {
            string contactNumber = string.Empty;
            if (workNo == "00000000000000000000")
            {
                contactNumber = "0000000000";
            }

            if (workNo == "")
            {
                if (cellNo == "")
                {
                    contactNumber = homeNo;
                }
                else
                {
                    contactNumber = cellNo;
                }
            }

            if (contactNumber == "")
            {
                contactNumber = "Not supplied";
            }

            return contactNumber;
        }

        /// <summary>
        /// Convert date if not null with SA region date format
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public static DateTime? ConvertToDateTime(string inputDate)
        {
            CultureInfo culture = new CultureInfo(Constants.CalenderCulture);

            if (!string.IsNullOrEmpty(inputDate))
            {
                return Convert.ToDateTime(inputDate, culture);
            }
            else
            {
                return null;
            }
        }

        public static bool ByPassWebSeal
        {
            get
            {
                return Properties.Resource.ByPassWebSeal == "1";

            }
        }




        /// <summary>
        /// Convert date time format
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string CovertDateTimeFormat(DateTime? datetime)
        {
            return (datetime != null && datetime != DateTime.MinValue) ? datetime.Value.ToString(Constants.DateFormat) : string.Empty;
        }

        /// <summary>
        /// From and to date to search lead details
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string[] CovertDateTimeFormat(string datetime)
        {
            string[] dateRange = new string[2];
            if (!string.IsNullOrEmpty(datetime))
            {
                dateRange[0] = GetDateFormateDateRange(datetime.Split('-')[0].ToString());
                dateRange[1] = GetDateFormateDateRange(datetime.Split('-')[1].ToString());
            }

            return dateRange;
        }
        public static string GetDateFormateDateRange(string dateRange)
        {
            CultureInfo culture = new CultureInfo(Constants.CalenderCulture);
            DateTime date = Convert.ToDateTime(dateRange, culture);
            if (date != null)
            {
                return date.Year.ToString() + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00");
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Date time parse as per required format
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns></returns>
        public static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }


    }

}
