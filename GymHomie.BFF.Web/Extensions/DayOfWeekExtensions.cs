using System;
using System.Globalization;

namespace GymHomie.BFF.Web.Extensions
{
    public static class DayOfWeekExtensions
    {
        public static string GetDayName(this DayOfWeek dayOfWeek, CultureInfo culture)
        {
            var day = culture.DateTimeFormat.GetDayName(dayOfWeek);
            if (string.IsNullOrEmpty(day))
                return string.Empty;

            return culture.TextInfo.ToTitleCase(day);
        }
    }
}
