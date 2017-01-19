using System;
using System.Linq;
using Foundation;
using UserNotifications;
using WideWorldCalendar.iOS.Utilities;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.Utilities;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotification_iOS))]
namespace WideWorldCalendar.iOS.Utilities
{
    public class LocalNotification_iOS : ILocalNotification
    {
        public void ScheduleGameNotifications()
        {
            ClearAllNotifications();
            var dataInstance = Data.GetInstance(new SQLite_iOS().GetConnection());

            if (dataInstance.ShowGameNotifications())
            {
                foreach (var notification in dataInstance.GetAllGameNotifications().Where(n => n.FirstGameTime.HasValue))
                {
                    // This is OK since we verify that it has value in the foreach. just annoyed by the squiggly
                    // ReSharper disable once PossibleInvalidOperationException
                    var gameDate = notification.FirstGameTime.Value.Date;
                    var notificationPreferences = dataInstance.GetGameNotificationPreferences();
                    int preferredHour = TimeConversionUtil.ConvertHourPreferenceTo24Hour(notificationPreferences);

                    var notificationTime =
                        gameDate.AddHours(preferredHour)
                            .AddDays(notificationPreferences.Day == DayPreference.TheDayOfTheGame ? 0 : -1);

                    
                    if (notificationTime > DateTime.Now)
                    {
                        CreateNotification(notificationTime, notification.Title, notification.Message, notification.TeamId, Constants.GameNotification);
                    }
                }
            }
        }

        public void ClearAllNotifications()
        {
            UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();
        }

        public void CreateNotification(DateTime notificationTime, string title, string message, int requestIdCode, string notificationType)
        {
            notificationTime = DateTime.Now.AddMinutes(1);
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
                UNNotificationTrigger trigger = UNCalendarNotificationTrigger.CreateTrigger(dateComponants, false);
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
