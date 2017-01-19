using Android.Content;
using WideWorldCalendar.Droid.Utilities;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    public class BasicNotificationBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            LocalNotification_Android.CreateBasicNotification(context, intent.GetIntExtra(Constants.NotificationRequestCodeKey, -1),
                intent.GetStringExtra(Constants.NotificationTitleKey),
                intent.GetStringExtra(Constants.NotificationMessageKey));
        }
    }
}