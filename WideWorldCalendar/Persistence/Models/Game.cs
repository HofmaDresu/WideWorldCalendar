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
        public int? MyTeamScore { get; set; }
        public int? OpposingTeamScore { get; set; }

        [Ignore]
        public OpposingTeam OpposingTeam { get; set; }
        [Ignore]
        public string WinLoss => !(MyTeamScore.HasValue && OpposingTeamScore.HasValue) ? null : MyTeamScore.Value == OpposingTeamScore.Value ? Constants.Tie : MyTeamScore.Value > OpposingTeamScore.Value ? Constants.Win : Constants.Loss;
    }
}
