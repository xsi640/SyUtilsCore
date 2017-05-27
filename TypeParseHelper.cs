using System;
using System.Net;

namespace SyUtilsCore
{
    public class TypeParseHelper
    {
        public static int StrToInt32(string str, int defaultValue = 0)
        {
            int result = defaultValue;
            Int32.TryParse(str, out result);
            return result;
        }

        public static long StrToInt64(string str, long defaultValue = 0)
        {
            long result = defaultValue;
            Int64.TryParse(str, out result);
            return result;
        }

        public static double StrToDouble(string str, double defaultValue = 0)
        {
            double result = defaultValue;
            Double.TryParse(str, out result);
            return result;
        }

        public static bool StrToBoolean(string str, bool defaultValue = false)
        {
            bool result = defaultValue;
            Boolean.TryParse(str, out result);
            return result;
        }

        public static decimal StrToDecimal(string str, decimal defaultValue = 0)
        {
            decimal result = defaultValue;
            Decimal.TryParse(str, out result);
            return result;
        }

        public static Guid StrToGuid(string str, Guid? defaultValue = null)
        {
            Guid result = defaultValue ?? Guid.Empty;
            Guid.TryParse(str, out result);
            return result;
        }

        public static DateTime StrToDateTime(string str, DateTime? defaultValue = null)
        {
            DateTime result = defaultValue ?? DateTime.Now;
            DateTime.TryParse(str, out result);
            return result;
        }

        public static TimeSpan StrToTimeSpan(string str, TimeSpan? defaultValue = null)
        {
            TimeSpan result = defaultValue ?? TimeSpan.Zero;
            TimeSpan.TryParse(str, out result);
            return result;
        }

        public static IPAddress StrToIPAddress(string str, IPAddress defaultValue = null)
        {
            IPAddress result = defaultValue ?? IPAddress.Any;
            IPAddress.TryParse(str, out result);
            return result;
        }

        public static string ObjToStr(object obj, string defaultValue = null)
        {
            string result = defaultValue ?? string.Empty;
            if (obj != null)
            {
                result = obj.ToString();
            }
            return result;
        }
    }
}