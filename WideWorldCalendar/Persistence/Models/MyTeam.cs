using System;
using SQLite.Net.Attributes;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("MyTeams")]
    public class MyTeam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamColor { get; set; }
        public string Division { get; set; }
        public DateTime LastGame { get; set; }
    }
}
