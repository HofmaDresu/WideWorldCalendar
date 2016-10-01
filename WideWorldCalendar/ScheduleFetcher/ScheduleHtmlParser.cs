using System;
using System.Linq;
using System.Collections.Generic;

namespace WideWorldCalendar.ScheduleFetcher
{
	public static class ScheduleHtmlParser
	{
		// Yield returns aren't really needed, but it was fun to write them
		// This whole process could be much more efficient, but for now i'm being lazy

		public static IEnumerable<string> GetSeasons(string html)
		{
			var seasonSections = html.Split(new[] { "Season: </strong>" }, StringSplitOptions.RemoveEmptyEntries);

			if (seasonSections.Length <=1) yield break;

			for (int i = 1; i < seasonSections.Length; i++)
			{
				var section = seasonSections[i];
				var sectionName = section.Substring(0, section.IndexOf('<'));
				yield return CleanString(sectionName);
			}
		}

		public static IEnumerable<string> GetScheduleGroupings(string html, string season)
		{
			var seasonSections = html.Split(new[] { "Season: </strong>" }, StringSplitOptions.RemoveEmptyEntries);

			if (seasonSections.Length <= 1) yield break;

			var selectedSeasonSections = seasonSections.Where(s => s.Contains(season)).ToList();
			if (selectedSeasonSections.Count != 1) yield break;

			var scheduleGroupingSections = selectedSeasonSections[0].Split(new[] { "<span class=\"style128\">" }, StringSplitOptions.RemoveEmptyEntries);
			if (scheduleGroupingSections.Length <= 1) yield break;


			for (int i = 1; i < scheduleGroupingSections.Length; i++)
			{
				var section = scheduleGroupingSections[i];
				var sectionName = section.Substring(0, section.IndexOf('<'));
				yield return CleanString(sectionName);
			}
		}

		public static IEnumerable<NavigationOption> GetDivisions(string html, string season, string schedule)
		{
			var seasonSections = html.Split(new[] { "Season: </strong>" }, StringSplitOptions.RemoveEmptyEntries);

			if (seasonSections.Length <= 1) yield break;

			var selectedSeasonSections = seasonSections.Where(s => s.Contains(season)).ToList();
			if (selectedSeasonSections.Count != 1) yield break;

			var scheduleGroupingSections = selectedSeasonSections[0].Split(new[] { "<span class=\"style128\">" }, StringSplitOptions.RemoveEmptyEntries);
			if (scheduleGroupingSections.Length <= 1) yield break;

			var selectedGroupingSections = scheduleGroupingSections.Where(s => s.Contains(schedule)).ToList();
			if (selectedGroupingSections.Count != 1) yield break;

			var divisionSections = selectedGroupingSections[0].Split(new[] { "ID=" }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 1; i < divisionSections.Length; i++)
			{
				var divisionSection = divisionSections[i];
				var id = divisionSection.Split('\'')[0];

				var name = divisionSection.Split('>')[1].Split('<')[0];

				yield return new NavigationOption { Id = int.Parse(id), Name = name };
			}
		}

		public static IEnumerable<NavigationOption> GetTeams(string html)
		{
			var teamSections = html.Split(new[] { "PrintTeamSchedule.asp?ID=" }, StringSplitOptions.RemoveEmptyEntries);
			if (teamSections.Length <= 1) yield break;

			for (int i = 1; i < teamSections.Length; i++)
			{
				var scheduleTypeSection = teamSections[i];
				var id = scheduleTypeSection.Split('\'')[0];

				var name = scheduleTypeSection.Split('>')[1].Split('<')[0];


				yield return new NavigationOption { Id = int.Parse(id), Name = name };
			}

		}

		public static IEnumerable<Game> GetTeamSchedule(string html)
		{
			var teamListTable = html.Split(new[] { "Team Contacts" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new[] { "<table" }, StringSplitOptions.RemoveEmptyEntries)[1];

			var teamRows = teamListTable.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var row in teamRows)
			{
				if (row.StartsWith(" width", StringComparison.CurrentCultureIgnoreCase)) continue;
				if (row.Contains("/table>")) break;

				var foo = 1;
			}

			yield break;
		}

		private static string CleanString(string source)
		{
			return source.Replace("\n", "").Trim();
		}
	}
}
