using SQLite;
using System;
using Xamarin.Forms;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("TeamColors")]
    class TeamColor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int TeamColorRed { get; set; }
        public int TeamColorGreen { get; set; }
        public int TeamColorBlue { get; set; }
        [Ignore]
        public Color TeamColor
        {
            get
            {
                return Color.FromRgb(TeamColorRed, TeamColorGreen, blueValue);
            }
        }
    }
}
