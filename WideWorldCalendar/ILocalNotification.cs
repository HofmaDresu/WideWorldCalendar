using System;

namespace WideWorldCalendar
{
    public interface ILocalNotification
    {
        void ScheduleGameNotification(string title, string message, int gameId, DateTime notificationTime);
    }
}
