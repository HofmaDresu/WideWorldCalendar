using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("OpposingTeams")]
    public class OpposingTeam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamColor { get; set; }
        [Ignore]
        public string NameAndColor => $"{TeamName} ({TeamColor})";
    }
}
