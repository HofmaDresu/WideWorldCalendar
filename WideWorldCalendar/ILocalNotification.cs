using System;

namespace WideWorldCalendar
{
    public interface ILocalNotification
    {
        void ScheduleGameNotifications();
        void ClearAllNotifications();
    }
}
