using System;
using System.Collections.Generic;
using System.Text;
using WideWorldCalendar.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotification_iOS))]
namespace WideWorldCalendar.iOS
{
    public class LocalNotification_iOS : ILocalNotification
    {
        public void ScheduleGameNotification()
        {
        }
    }
}
