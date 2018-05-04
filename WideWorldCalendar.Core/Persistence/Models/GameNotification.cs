using System;

namespace WideWorldCalendar.Persistence.Models
{
    public class GameNotification
    {
        public int TeamId { get; set; }
        public string TeamNameAndColor { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? FirstGameTime { get; set; }
    }
}
