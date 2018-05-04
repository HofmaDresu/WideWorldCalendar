using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public interface IScheduleFetcher
	{
		Task<string> GetSchedulesPage();

		List<string> GetSeasons(string schedulePageHtml);
		List<string> GetScheduleGroupings(string schedulePageHtml, string season);
		List<NavigationOption> GetDivisions(string schedulePageHtml, string season, string schedule);
		Task<List<NavigationOption>> GetTeams(int divisionId);
		Task<List<Game>> GetTeamSchedule(int teamId);
	}
}
