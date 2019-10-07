using System;

namespace CSharpHacks
{
    public static class DoubleHacks
    {
        public static bool IsZero(this double @this) =>
            @this.IsCloseTo(0, 0.0000001);

        public static bool IsCloseTo(this double @this, double value, double tolerance) =>
            (@this - value) <= tolerance;

        public static DateTime ToDateTime(this double date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(date);
        }        
        
        public static DateTime ToDateTimeMs(this double date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(date);
        }
    }
}
