using System;
namespace WideWorldCalendar.ScheduleFetcher
{
	public class Game
	{
		public DateTime ScheduledDateTime { get; set; }
		public string GameTimeString => ScheduledDateTime.ToString("d") + " " + ScheduledDateTime.ToString("t");
		public string Field { get; set; }
		public bool IsHomeGame { get; set; }
		public Team MyTeam { get; set; }
		public Team OpposingTeam { get; set; }
	}
}
