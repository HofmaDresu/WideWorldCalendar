using System;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("Games")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int MyTeamId { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public string Field { get; set; }
        public bool IsHomeGame { get; set; }
        public int OpposingTeamId { get; set; }

        [Ignore]
        public OpposingTeam OpposingTeam { get; set; }
    }
}
