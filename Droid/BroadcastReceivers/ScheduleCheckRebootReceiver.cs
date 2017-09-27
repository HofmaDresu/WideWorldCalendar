using Android.App;
using Android.Content;
using WideWorldCalendar.Droid.Utilities;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.LowPriority)]
    public class ScheduleCheckRebootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            new LocalNotification_Android().ScheduleGameNotification(context, true);
        }
    }
}