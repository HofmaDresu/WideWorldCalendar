﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WideWorldCalendar.Persistence.Models
{
    [Table("Games")]
    public class DeviceData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool ShowGameNotifications { get; set; }
        public bool ShowScheduleChangedNotifications { get; set; }
        public bool ShowNewSeasonAvailableNotifications { get; set; }
    }
}
