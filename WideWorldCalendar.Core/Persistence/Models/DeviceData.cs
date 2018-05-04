using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("DeviceData")]
    public class DeviceData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool ShowGameNotifications { get; set; }
        public bool ShowScheduleChangedNotifications { get; set; }
        public bool ShowNewSeasonAvailableNotifications { get; set; }
    }
}
