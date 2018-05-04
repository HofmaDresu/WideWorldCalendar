using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldCalendar.Persistence.Models;

namespace WideWorldCalendar.Utilities
{
    public static class TimeConversionUtil
    {
        public static int ConvertHourPreferenceTo24Hour(GameNotificationPreference preferences)
        {
            if (preferences.Meridian == Meridian.Am)
            {
                return preferences.Hour == 12 ? 0 : preferences.Hour;
            }
            else
            {
                return preferences.Hour == 12 ? 12 : preferences.Hour + 12;
            }
        }
    }
}
