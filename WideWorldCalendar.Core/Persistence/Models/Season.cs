using System;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("Seasons")]
    public class Season : IEquatable<Season>
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }

        public static bool operator ==(Season left, Season right) => Equals(left, right);

        public static bool operator !=(Season left, Season right) => !Equals(left, right);

        public bool Equals(Season other)
        {
            return (Id, Name) == (other.Id, other.Name);
        }

        public override bool Equals(object obj)
        {
            return (obj is Season season) && Equals(season);
        }

        public override int GetHashCode()
        {
            return (Id, Name).GetHashCode();
        }
    }
}
