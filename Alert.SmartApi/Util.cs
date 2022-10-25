using System;

namespace Alert.SmartApi
{
    public static class Util
    {
        public static DateTime ToIstDateTime(this DateTime utcdate)
        {
            DateTime dt = DateTime.SpecifyKind(utcdate, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
    }
}
