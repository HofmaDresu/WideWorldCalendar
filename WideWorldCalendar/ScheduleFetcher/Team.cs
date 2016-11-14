using System;
namespace WideWorldCalendar.ScheduleFetcher
{
	public class Team
	{
		public string Name { get; set; }
		public string Color { get; set; }
		public string NameAndColor => $"{Name} ({Color})";
	}
}
