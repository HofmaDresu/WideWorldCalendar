using Foundation;
using System;
using UserNotifications;

namespace WideWorldCalendar.iOS
{
    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            var notificationInfo = response.Notification.Request.Identifier.Split(':')[0];
            var notificationType = notificationInfo.Split('_')[0];
            var notificationId = notificationInfo.Split('_')[1];

            App.GetInstance().OnAppLinkRequestReceived_WorkAround(new NSUrl(WideWorldCalendar.Constants.ScheduleDeepLinkUrl + notificationId));

            completionHandler();
        }
    }
}
