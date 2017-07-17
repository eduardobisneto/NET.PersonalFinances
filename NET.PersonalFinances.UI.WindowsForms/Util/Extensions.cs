using System;

namespace NET.PersonalFinances.UI.WindowsForms.Util
{
    public static class Extensions
    {
        public static DateTime GetSundayBefore(this DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Sunday)
                date = date.AddDays(-1);

            return date;
        }

        public static DateTime ToDate(this string date)
        {
            return Convert.ToDateTime(date);
        }
    }
}
