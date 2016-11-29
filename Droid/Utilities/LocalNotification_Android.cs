using System;
using Android.App;
using Android.Content;
using WideWorldCalendar.Droid.BroadcastReceivers;
using WideWorldCalendar.Droid.Utilities;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotification_Android))]
namespace WideWorldCalendar.Droid.Utilities
{
    public class LocalNotification_Android : ILocalNotification
    {
        public void ScheduleGameNotifications()
        {
            ScheduleGameNotification(Forms.Context);
        }

        public void ScheduleGameNotification(Context packageContext)
        {
            var checkTime = DateTime.Now.Date.AddHours(9);

            if (DateTime.Now.Hour > 8)
            {
                checkTime = checkTime.AddDays(1);
            }

            var reminder = new Intent(packageContext, typeof (ScheduleCheckBroadcastReceiver));

            var reminderBroadcast = PendingIntent.GetBroadcast(packageContext, Constants.ScheduleCheckRequestCode, reminder,
                PendingIntentFlags.CancelCurrent);
            var alarms = (AlarmManager) packageContext.GetSystemService(Context.AlarmService);

            var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var notificationTimeMilliseconds = checkTime.ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
            alarms.SetExact(AlarmType.RtcWakeup,
                (long) notificationTimeMilliseconds,
                reminderBroadcast);
        }

        public void ClearAllNotifications()
        {
            //No implementation needed on Android. No notifications are "scheduled", and this is fully controlled in the ScheduleCheckBroadcastReceiver
        }
    }
}