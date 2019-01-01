using SQLite;
using System;
using Xamarin.Forms;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("TeamColors")]
    public class TeamColor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TeamColorRed { get; set; }
        public int TeamColorGreen { get; set; }
        public int TeamColorBlue { get; set; }
        [Ignore]
        public Color Color
        {
            get
            {
                return Color.FromRgb(TeamColorRed, TeamColorGreen, TeamColorBlue);
            }
        }
    }
}
