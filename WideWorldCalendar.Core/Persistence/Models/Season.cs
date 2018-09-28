using System;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("Seasons")]
    public class Season : IEquatable<Season>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // only used for DB, not used in equality checks
        public int ScheduleId { get; set; }
        public string Name { get; set; }

        public static bool operator ==(Season left, Season right) => Equals(left, right);

        public static bool operator !=(Season left, Season right) => !Equals(left, right);

        public bool Equals(Season other)
        {
            return ClassTouple() == other.ClassTouple();
        }

        public override bool Equals(object obj)
        {
            return (obj is Season season) && Equals(season);
        }

        public override int GetHashCode()
        {
            return ClassTouple().GetHashCode();
        }

        public (int, string) ClassTouple() => (ScheduleId, Name);
    }
}
