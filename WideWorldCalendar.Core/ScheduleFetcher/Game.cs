using System;
namespace WideWorldCalendar.ScheduleFetcher
{
	public class Game
	{
		public DateTime ScheduledDateTime { get; set; }
		public string Field { get; set; }
		public bool IsHomeGame { get; set; }
		public Team MyTeam { get; set; }
		public Team OpposingTeam { get; set; }
        public int? MyTeamScore { get; set; }
        public int? OpposingTeamScore { get; set; }
    }
}
