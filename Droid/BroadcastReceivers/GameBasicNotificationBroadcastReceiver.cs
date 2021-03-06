using Android.Content;
using WideWorldCalendar.Droid.Utilities;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    public class GameNotificationBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            LocalNotification_Android.CreateGameNotification(context, intent.GetIntExtra(Constants.NotificationRequestCodeKey, -1),
                intent.GetStringExtra(Constants.NotificationTitleKey),
                intent.GetStringExtra(Constants.NotificationMessageKey));
        }
    }
}