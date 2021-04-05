using System;

namespace Core.Libs.Utils.Helpers
{
    public static class DateTimeExtensions
    {
        private static DateTime startingDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        
        public static DateTime GetDateTime(this long timestamp, bool isJava = false)
        {
            return isJava
                ? DateTimeExtensions.startingDate.AddMilliseconds(timestamp)
                : DateTimeExtensions.startingDate.AddSeconds(timestamp);
        }
        public static long GetTimestamp(this DateTime date, bool isJava = false)
        {
            var timespan = date - DateTimeExtensions.startingDate;

            return (long) (isJava ? timespan.TotalMilliseconds : timespan.TotalSeconds);
        }

        public static DateTime ToStartDateTime(
           this DateTime item)
        {
            return item.ToDateTime(new DateTime()).StartDateTime();
        }
        public static DateTime ToEndDateTime(
            this DateTime item)
        {
            return item.ToDateTime(new DateTime()).EndDateTime();
        }
        public static DateTime ToDateTime(
            this DateTime item,
            DateTime defaultDateTime = default(DateTime))
        {
            return new DateTime(item.Ticks);
        }
        public static DateTime StartDateTime(
            this DateTime item)
        {
            return new DateTime(item.Year, item.Month, item.Day);
        }
        public static DateTime EndDateTime(
            this DateTime item)
        {
            return new DateTime(item.Year, item.Month, item.Day, 23, 59, 59);
        }
    }
}