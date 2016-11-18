﻿using System;
namespace WideWorldCalendar.ScheduleFetcher
{
	public class Team
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
        public string Division { get; set; }
		public string NameAndColor => $"{Name} ({Color})";
	}
}
