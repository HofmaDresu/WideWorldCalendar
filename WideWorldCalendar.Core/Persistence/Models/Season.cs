using System;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("Seasons")]
    public class Season
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
