using System;
using System.Linq;

namespace GymHomie.BFF.Web.Helpers
{
    public static class DayOfWeekHelper
    {
        public static DayOfWeek[] GetDays()
        {
            return Enum.GetValues<DayOfWeek>()
                .OrderBy(d => (int)d == 0 ? 7 : (int)d)
                .ToArray();
        }
    }
}
