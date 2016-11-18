﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class RestScheduleFetcher : IScheduleFetcher
	{
		public async Task<string> GetSchedulesPage()
		{
			var client = new HttpClient();
			return await client.GetStringAsync("https://secure.wideworld-sports.me/wws_membership/SchedulesScoresDisplay.asp");
		}

		public List<string> GetSeasons(string schedulePageHtml)
		{
			return ScheduleHtmlParser.GetSeasons(schedulePageHtml).ToList();
		}

		public List<NavigationOption> GetDivisions(string schedulePageHtml, string season, string schedule)
		{
			return ScheduleHtmlParser.GetDivisions(schedulePageHtml, season, schedule).ToList();
		}

		public List<string> GetScheduleGroupings(string schedulePageHtml, string season)
		{
			return ScheduleHtmlParser.GetScheduleGroupings(schedulePageHtml, season).ToList();
		}

		public async Task<List<NavigationOption>> GetTeams(int divisionId)
		{
			var client = new HttpClient();
			var divisionReportHtml = await client.GetStringAsync($"https://secure.wideworld-sports.me/wws_membership/DivisionReport.asp?ID={divisionId}");
			return ScheduleHtmlParser.GetTeams(divisionReportHtml).ToList();
		}

		public async Task<List<Game>> GetTeamSchedule(int teamId)
		{
			var client = new HttpClient();
			var divisionReportHtml = await client.GetStringAsync($"https://secure.wideworld-sports.me/wws_membership/PrintTeamSchedule.asp?ID={teamId}");
			return ScheduleHtmlParser.GetTeamSchedule(teamId, divisionReportHtml).ToList();
		}
	}
}
