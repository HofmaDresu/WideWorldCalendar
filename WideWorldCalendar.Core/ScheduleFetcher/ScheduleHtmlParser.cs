using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace WideWorldCalendar.ScheduleFetcher
{
	public static class ScheduleHtmlParser
	{
		// Yield returns aren't really needed, but it was fun to write them
		// This whole process could be much more efficient, but for now i'm being lazy

		public static IEnumerable<NavigationOption> GetSeasons(string html)
		{
            var afterCurrentSessionsHtml = html.Split(new[] { "<optgroup label='Current Seasons'>" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            if (string.IsNullOrEmpty(afterCurrentSessionsHtml)) yield break;
            var currentSessionItemsHtml = afterCurrentSessionsHtml.Split(new[] { "<optgroup" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            if (string.IsNullOrEmpty(currentSessionItemsHtml)) yield break;

            var individualSessionItems = currentSessionItemsHtml.Split(new[] { "</option" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var sessionItem in individualSessionItems.Where(s => s.Contains("option")))
            {
                var sessionIdString = sessionItem.Split(new[] { "value=\"", "\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                if (!int.TryParse(sessionIdString, out int sessionId)) continue;

                var sessionName = sessionItem.Split(new[] { ">" }, StringSplitOptions.RemoveEmptyEntries)[1];
                yield return new NavigationOption(sessionId, CleanString(sessionName));
            }
		}

		public static Dictionary<string, List<NavigationOption>> GetLeagues(string html)
		{
            var leagueDictionary = new Dictionary<string, List<NavigationOption>>();

            var leagueSections = html.Split(new[] { "<table class=\"table table-striped\">" }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            foreach (var section in leagueSections)
            {

                var leagueName = CleanString(section.Split(new[] { "League Standings: " }, StringSplitOptions.RemoveEmptyEntries).Last()
                    .Split(new[] { "<" }, StringSplitOptions.RemoveEmptyEntries).First());

                var teamRows = section.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries).Where(s => !s.Contains("/table")).Skip(2);
                var teamItems = new List<NavigationOption>();

                foreach (var row in teamRows)
                {
                    var teamName = row.Split(new[] { "</a>" }, StringSplitOptions.RemoveEmptyEntries).First()
                        .Split(new[] { "\">" }, StringSplitOptions.RemoveEmptyEntries).Last();
                    var teamIdString = row.Split(new[] { "teamid=" }, StringSplitOptions.RemoveEmptyEntries).Last()
                        .Split(new[] { "\">" }, StringSplitOptions.RemoveEmptyEntries).First();
                    if (!int.TryParse(teamIdString, out int teamId)) continue;

                    teamItems.Add(new NavigationOption(teamId, CleanString(teamName).Trim()));
                }

                leagueDictionary[leagueName] = teamItems;
            }

            return leagueDictionary;
		}

		public static IEnumerable<Game> GetTeamSchedule(int teamId, string html)
        {
            throw new NotImplementedException();
            var myTeamId = html.Split(new[] { "styleTeam" }, StringSplitOptions.RemoveEmptyEntries)[2]
							   .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1]
							   .Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0]
			                   .Trim();

		    var division = html.Split(new[] {"Season:"}, StringSplitOptions.RemoveEmptyEntries)[1]
		        .Split(new[] {"style81\">"}, StringSplitOptions.RemoveEmptyEntries)[1]
		        .Split(new[] {"<"}, StringSplitOptions.RemoveEmptyEntries)[0];



            var teamDictionary = new Dictionary<string, Team>();

			var teamListTable = html.Split(new[] { "Team Contacts" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new[] { "<table" }, StringSplitOptions.RemoveEmptyEntries)[1];

			var teamRows = teamListTable.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var row in teamRows)
			{
				if (row.StartsWith(" width", StringComparison.CurrentCultureIgnoreCase)) continue;
				if (row.Contains("/table>")) break;

				var columns = row.Split(new[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
				var team = new Team
				{
                    Id = teamId,
                    Name = GetValueFromColumn(columns[1]),
					Color = GetValueFromColumn(columns[5]),
                    Division = WebUtility.HtmlDecode(division),
                };

				teamDictionary.Add(GetValueFromColumn(columns[0]), team);
			}

			var scheduleTable = html.Split(new[] { "Schedules/Scores" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new[] { "<table" }, StringSplitOptions.RemoveEmptyEntries)[1];;

			var scheduleRows = scheduleTable.Split(new[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var row in scheduleRows)
			{
				if (row.StartsWith(" width", StringComparison.CurrentCultureIgnoreCase)) continue;
				if (row.Contains("/table>")) break;

				var columns = row.Split(new[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);

				var homeTeamId = GetValueFromColumn(columns[4]);
				var awayTeamId = GetValueFromColumn(columns[6]);
				var isHomeGame = homeTeamId == myTeamId;
                int homeTeamScoreInt;
                var homeTeamScore = int.TryParse(GetValueFromColumn(columns[5]), out homeTeamScoreInt) ? homeTeamScoreInt : (int?)null;
                int awayTeamScoreInt;
                var awayTeamScore = int.TryParse(GetValueFromColumn(columns[7]), out awayTeamScoreInt) ? awayTeamScoreInt : (int?)null;

                yield return new Game
				{
					ScheduledDateTime = DateTime.Parse(GetValueFromColumn(columns[0]) + " " + GetValueFromColumn(columns[2])),
					Field = GetValueFromColumn(columns[3]),
					IsHomeGame = isHomeGame,
					MyTeam = teamDictionary[myTeamId],
					OpposingTeam = isHomeGame ? teamDictionary[awayTeamId] : teamDictionary[homeTeamId],
                    MyTeamScore = isHomeGame ? homeTeamScore : awayTeamScore,
                    OpposingTeamScore = isHomeGame ? awayTeamScore : homeTeamScore
                };
			}
			yield break;
		}

		private static string GetValueFromColumn(string column)
		{
			var substring = column.Split(new[] { "'style3'>" }, StringSplitOptions.RemoveEmptyEntries)[1];
			return CleanString(substring.Split('<')[0].Trim());
		}

		private static string CleanString(string source)
		{
			return WebUtility.HtmlDecode(source.Replace("\n", "").Trim());
		}
	}
}
