using System;
using System.Globalization;

namespace TestLoadBalancer
{
    public static class DateTimeExtensions
    {
        public static long ConvertToUnixTime(this DateTime datetime)
        {
            var sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long) (datetime - sTime).TotalSeconds;
        }

        public static int GetWeekNumber(this DateTime dateTime)
        {
            var ciCurr = CultureInfo.CurrentCulture;
            var weekNum = ciCurr.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }
    }
}