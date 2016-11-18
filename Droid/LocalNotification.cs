using System;
using Android.App;
using Android.Content;
using WideWorldCalendar.Droid;
using WideWorldCalendar.Droid.BroadcastReceivers;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotification_Android))]
namespace WideWorldCalendar.Droid
{
    public class LocalNotification_Android : ILocalNotification
    {
        public void ScheduleGameNotification(string title, string message, int gameId, DateTime notificationTime)
        {
            var reminder = new Intent(Forms.Context, typeof(GameNotificationBroadcastReceiver));
            reminder.PutExtra(Constants.NotificationTitleKey, title);
            reminder.PutExtra(Constants.NotificationMessageKey, message);

            var reminderBroadcast = PendingIntent.GetBroadcast(Forms.Context, gameId, reminder, PendingIntentFlags.CancelCurrent);
            var alarms = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);


            var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var notificationTimeMilliseconds = notificationTime.ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
            alarms.SetExact(AlarmType.RtcWakeup,
                (long)notificationTimeMilliseconds,
                reminderBroadcast);
        }

        public void ScheduleGameNotification(DateTime notificationTime)
        {
            var reminder = new Intent(Forms.Context, typeof(ScheduledNotificationBroadcastReceiver));

            var reminderBroadcast = PendingIntent.GetBroadcast(Forms.Context, 0, reminder, PendingIntentFlags.CancelCurrent);
            var alarms = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);


            var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var notificationTimeMilliseconds = notificationTime.ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
            alarms.SetExact(AlarmType.RtcWakeup,
                (long)notificationTimeMilliseconds,
                reminderBroadcast);
        }
    }
}