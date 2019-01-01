using SQLite;
using System;
using Xamarin.Forms;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("OpposingTeams")]
    public class OpposingTeam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int? ServerId { get; set; }
        public string TeamName { get; set; }
        [Obsolete("Use 'Color' instead")]
        public string TeamColor { get; set; }
        [Ignore]
        public Color Color { get; set; }
    }
}
