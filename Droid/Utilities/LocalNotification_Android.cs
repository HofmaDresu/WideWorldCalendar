using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using WideWorldCalendar.Droid.BroadcastReceivers;
using WideWorldCalendar.Droid.Utilities;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(LocalNotification_Android))]
namespace WideWorldCalendar.Droid.Utilities
{
    public class LocalNotification_Android : ILocalNotification
    {
        public void ScheduleGameNotifications()
        {
            ScheduleGameNotification(MainActivity.Context, true);
        }

        public void ScheduleGameNotification(Context packageContext, bool instantCheck = false)
        {
            var checkTime = instantCheck ? DateTime.Now : DateTime.Now.Date.AddMinutes(1);

            if (DateTime.Now > checkTime && ! instantCheck)
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
        
        public static void CreateBasicNotification(Context context, int requestCode, string title, string message)
        {
            var builder = GetBuilder(context, Constants.GeneralNotificationChannelId)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetPriority((int)NotificationPriority.Low)
                .SetVisibility(NotificationCompat.VisibilityPublic)
                .SetCategory("reminder")
                .SetSmallIcon(Resource.Drawable.icon_notification_plain)
                .SetColor(Colors.PrimaryColor.ToAndroid());

            var notification = builder.Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(requestCode, notification);
        }

        public static void CreateGameNotification(Context context, int teamId, string title, string message)
        {
            var notificationIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(WideWorldCalendar.Constants.ScheduleDeepLinkUrl + teamId));
            var clickPendingIntent = PendingIntent.GetActivity(context, 0, notificationIntent, 0);

            var builder = GetBuilder(context, Constants.GameNotificationChannelId)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetPriority((int)NotificationPriority.Low)
                .SetVisibility(NotificationCompat.VisibilityPublic)
                .SetCategory("reminder")
                .SetSmallIcon(Resource.Drawable.icon_notification_plain)
                .SetColor(Colors.PrimaryColor.ToAndroid());

            var notification = builder
                .SetContentIntent(clickPendingIntent)
                .Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(teamId, notification);
        }

        private static NotificationCompat.Builder GetBuilder(Context context, string channelId)
        {
            return Build.VERSION.SdkInt >= BuildVersionCodes.O ? new NotificationCompat.Builder(context, channelId) : new NotificationCompat.Builder(context);
        }
    }
}