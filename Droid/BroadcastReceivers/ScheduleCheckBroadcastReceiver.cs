using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using WideWorldCalendar.Persistence;
using Xamarin.Forms;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    public class ScheduleCheckBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            foreach (var notification in Data.GetInstance().GetTodaysNotifications())
            {
                CreateNotification(context, notification.TeamId, notification.Title, notification.Message);
            }

            DependencyService.Get<ILocalNotification>().ScheduleGameNotification();
        }

        private static void CreateNotification(Context context, int requestCode, string title, string message)
        {
            var builder = new NotificationCompat.Builder(context)
                .SetContentTitle(title)
                .SetContentText(message);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                builder
                    .SetPriority((int) NotificationPriority.Low)
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetCategory("reminder")
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else if ((int) Build.VERSION.SdkInt >= 20)
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
    }
}