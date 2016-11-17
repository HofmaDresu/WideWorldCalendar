using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace WideWorldCalendar.Droid
{
    [BroadcastReceiver]
    public class GameNotificationBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var builder = new NotificationCompat.Builder(context)
                .SetContentTitle(intent.GetStringExtra(Constants.NotificationTitleKey))
                .SetContentText(intent.GetStringExtra(Constants.NotificationMessageKey))
                .SetDefaults(NotificationCompat.DefaultSound | NotificationCompat.DefaultVibrate);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                builder
                    .SetPriority((int)NotificationPriority.High)
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetCategory("reminder")
                    .SetSmallIcon(Resource.Drawable.icon);
            }
            else if ((int)Build.VERSION.SdkInt >= 20)
            {
                builder
                    .SetSmallIcon(Resource.Drawable.icon);
            }
            else
            {
                // Disable obsolete warning 'cause this was how you do it pre-20
#pragma warning disable 618
                builder
                    .SetSmallIcon(Resource.Drawable.icon);
#pragma warning restore 618
            }

            var notification = builder.Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(1, notification);
        }
    }
}