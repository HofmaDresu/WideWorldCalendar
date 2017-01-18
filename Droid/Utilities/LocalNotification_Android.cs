using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
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
            ScheduleGameNotification(Forms.Context, true);
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
            var builder = new NotificationCompat.Builder(context)
                .SetContentTitle(title)
                .SetContentText(message);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                builder
                    .SetPriority((int)NotificationPriority.Low)
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetCategory("reminder")
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else if ((int)Build.VERSION.SdkInt >= 20)
            {
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else
            {
                // Disable obsolete warning 'cause this was how you do it pre-20
#pragma warning disable 618
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
#pragma warning restore 618
            }

            var notification = builder.Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(requestCode, notification);
        }

        public static void CreateGameNotification(Context context, int teamId, string title, string message)
        {
            var notificationIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse($"wwc://WideWorldCalendar/TeamSchedule?id={teamId}"));
            var clickPendingIntent = PendingIntent.GetActivity(context, 0, notificationIntent, 0);

            var builder = new NotificationCompat.Builder(context)
                .SetContentTitle(title)
                .SetContentText(message);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                builder
                    .SetPriority((int)NotificationPriority.Low)
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetCategory("reminder")
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else if ((int)Build.VERSION.SdkInt >= 20)
            {
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else
            {
                // Disable obsolete warning 'cause this was how you do it pre-20
#pragma warning disable 618
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
#pragma warning restore 618
            }

            var notification = builder
                .SetContentIntent(clickPendingIntent)
                .Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(teamId, notification);
        }
    }
}