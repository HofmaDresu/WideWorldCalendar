using System;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("MyTeams")]
    public class MyTeam
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamColor { get; set; }
        public string Division { get; set; }
        public DateTime LastGameDateTime { get; set; }
        public bool SendGameTimeReminders { get; set; }

        [Ignore]
		public string NameAndColor => String.IsNullOrEmpty(TeamColor) ? TeamName : $"{TeamName} ({TeamColor})";
        [Ignore]
        public string Record { get; set; }
    }
}
