using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("GameNotificationPreference")]
    public class GameNotificationPreference
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Hour { get; set; }
        public Meridian Meridian { get; set; }
        public DayPreference Day { get; set; }
    }

    public enum Meridian
    {
        Am,
        Pm
    }

    public enum DayPreference
    {
        GameDay,
        DayBefore
    }
}
