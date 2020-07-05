using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace HP_StockDataCollector.Helper
{
    internal static class Helper
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime UnitTimeToDateTime(string unixtimeStr)
        {
            long unixTime = Convert.ToInt64(unixtimeStr);
            DateTime dateTime = Epoch;
            dateTime = dateTime.AddMilliseconds(unixTime).ToLocalTime();
            return dateTime;
        }
        public static long DateTimeToUnix(DateTime MyDateTime)
        {
            TimeSpan timeSpan = MyDateTime - new DateTime(1970, 1, 1, 0, 0, 0);
            return (long)timeSpan.TotalSeconds;
        }
        internal static string ValueString<T>(this T @enumValue)
        {
            string name = @enumValue.ToString();
            var attribute = @enumValue.GetType().GetMember(name).First().GetCustomAttribute(typeof(EnumMemberAttribute));
            if (attribute is EnumMemberAttribute attr && attr.IsValueSetExplicitly)
            {
                name = attr.Value;
            }
            return name;
        }

    }
}
