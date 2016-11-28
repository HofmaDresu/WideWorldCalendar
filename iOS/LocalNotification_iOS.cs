using System;
using System.Linq;
using Foundation;
using UserNotifications;
using WideWorldCalendar.iOS;
using WideWorldCalendar.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotification_iOS))]
namespace WideWorldCalendar.iOS
{
    public class LocalNotification_iOS : ILocalNotification
    {
        public void ScheduleGameNotifications()
        {
            var dataInstance = Data.GetInstance(new SQLite_iOS().GetConnection());

            if (dataInstance.ShowGameNotifications())
            {
                foreach (var notification in dataInstance.GetAllGameNotifications().Where(n => n.FirstGameTime.HasValue))
                {
                    CreateNotification(notification.FirstGameTime.Value.Date.AddHours(9), notification.Title, notification.Message, notification.TeamId, Constants.GameNotification);
                }
            }
        }

        public void ClearAllNotifications()
        {
            UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();
        }

        public void CreateNotification(DateTime notificationTime, string title, string message, int requestIdCode, string notificationType)
        {
            UNUserNotificationCenter.Current.GetNotificationSettings(settings =>
            {
                var alertsAllowed = settings.AlertSetting == UNNotificationSetting.Enabled;
                if (!alertsAllowed) return;

                var content = new UNMutableNotificationContent
                {
                    Title = title,
                    Body = message,
                    Badge = -1,
                    CategoryIdentifier = Constants.GameTonightNotification,
                };

                var dateComponants = new NSDateComponents
                {
                    Year = notificationTime.Year,
                    Month = notificationTime.Month,
                    Day = notificationTime.Day,
                    Hour = notificationTime.Hour,
                    Minute = notificationTime.Minute,
                    Second = notificationTime.Second
                };
                UNNotificationTrigger trigger = UNCalendarNotificationTrigger.CreateTrigger(dateComponants, true);
                string requestId = $"{notificationType}_{requestIdCode}:{dateComponants.Year}:{dateComponants.Month}:{dateComponants.Day}:{dateComponants.Hour}:{dateComponants.Minute}:{dateComponants.Second}";

                var request = UNNotificationRequest.FromIdentifier(requestId, content, trigger);

                UNUserNotificationCenter.Current.AddNotificationRequest(request, err =>
                {
                    if (err != null)
                    {
                        // Do something with error...
                    }
                });

            });

        }
    }
}
