using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class ScheduleFetcher : IScheduleFetcher
	{
		public List<NavigationOption> GetDivisions(string schedulePageHtml, string season, string schedule)
		{
			throw new NotImplementedException();
		}

		public List<string> GetScheduleGroupings(string schedulePageHtml, string season)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetSchedulesPage()
		{
			throw new NotImplementedException();
		}

		public List<string> GetSeasons(string schedulePageHtml)
		{
			throw new NotImplementedException();
		}

		public Task<List<NavigationOption>> GetTeams(int divisionId)
		{
			throw new NotImplementedException();
		}

		public Task<List<Game>> GetTeamSchedule(int teamId)
		{
			throw new NotImplementedException();
		}
	}
}
