using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public interface IScheduleFetcher
	{
		Task<List<NavigationOption>> GetSeasons();
		Task<Dictionary<string, List<NavigationOption>>> GetLeagues(int seasonId);
		Task<List<Game>> GetTeamSchedule(int teamId);
	}
}
