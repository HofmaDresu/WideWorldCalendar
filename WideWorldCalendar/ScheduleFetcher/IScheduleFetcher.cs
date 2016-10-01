using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public interface IScheduleFetcher
	{
		Task<List<string>> GetSeasons();
		Task<List<string>> GetScheduleGroupings(string season);
		Task<List<NavigationOption>> GetScheduleTypes(string season, string schedule);
		Task<List<NavigationOption>> GetTeams(int divisionId);
		Task<List<Game>> GetTeamSchedule(int teamId);
	}
}
