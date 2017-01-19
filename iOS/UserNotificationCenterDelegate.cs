using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
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

            if (notificationType == Constants.GameNotification)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl(WideWorldCalendar.Constants.ScheduleDeepLinkUrl + notificationId));
            }

            completionHandler();
        }
    }
}
