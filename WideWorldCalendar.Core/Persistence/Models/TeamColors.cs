using SQLite;
using System;
using Xamarin.Forms;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("TeamColors")]
    public class TeamColor
    {
        public TeamColor() { }
        public TeamColor(int id, double red, double green, double blue, double alpha)
        {
            Id = id;
            TeamColorRed = red;
            TeamColorGreen = green;
            TeamColorBlue = blue;
            TeamColorAlpha = alpha;
        }

        [PrimaryKey]
        public int Id { get; set; }
        public double TeamColorRed { get; set; }
        public double TeamColorGreen { get; set; }
        public double TeamColorBlue { get; set; }
        public double? TeamColorAlpha { get; set; }
        [Ignore]
        public Color Color
        {
            get
            {
                return Color.FromRgba(TeamColorRed, TeamColorGreen, TeamColorBlue, TeamColorAlpha.GetValueOrDefault(1));
            }
        }
    }
}
