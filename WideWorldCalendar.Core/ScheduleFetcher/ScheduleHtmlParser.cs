using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using WideWorldCalendar.Utilities;

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
            var scheduleSection = html.Split("<h3>Schedule</h3>").Last()
                .Split("<h3>League Standings</h3>").First();

            var gameSections = scheduleSection.Split("</li>").Where(s => s.Contains("li"));

            foreach (var section in gameSections)
            {
                var gameInfoSection = section.Split("col-5").Last().Split("col-7").First();
                var teamsInfoSection = section.Split("col-7").Last().Split("</table>").First();

                var game = new Game
                {
                    ScheduledDateTime = GetScheduledDateTime(gameInfoSection),
                    Field = CleanString(gameInfoSection.Split("<br>")[1]),
                };

                SetTeamInfo(teamId, teamsInfoSection, game);

                yield return game;
            }

        }

        private static void SetTeamInfo(int teamId, string teamsInfoSection, Game game)
        {
            var teamRows = teamsInfoSection.Split("</tr>").Where(s => s.Contains("<tr>")).ToList();
            for (int i = 0; i < teamRows.Count; i++)
            {
                var row = teamRows[i];
                var teamIdString = row.Split("teamid=").Last().Split("\">").First();
                if (!int.TryParse(teamIdString, out int currentTeamId)) continue;

                var teamColumns = row.Split("</td>").Where(s => s.Contains("<td")).ToArray();
                var hasScore = int.TryParse(teamColumns[0].Split('>').Last(), out int score);

                var team = new Team
                {
                    Id = currentTeamId,
                    Name = teamColumns[1].Split('>')[2].Split('<')[0],
                };

                if (currentTeamId == teamId)
                {
                    if (i == 0)
                    {
                        game.IsHomeGame = true;
                    }
                    game.MyTeam = team;
                    if (hasScore)
                    {
                        game.MyTeamScore = score;
                    }
                }
                else
                {
                    game.OpposingTeam = team;
                    if (hasScore)
                    {
                        game.OpposingTeamScore = score;
                    }
                }
            }
        }

        private static DateTime GetScheduledDateTime(string section)
        {
            var gameScheduleStrings = section.Split("<h4 class=\"list-group-item-heading\">").Last().Split("</h4>").First().Trim().Split(" ");
            var gameDateParts = gameScheduleStrings.First().Split('/').Select(int.Parse).ToArray();
            var isNight = gameScheduleStrings.Last().Contains("pm");
            var gameTimeParts = gameScheduleStrings.Last().Split(isNight ? "pm" : "am").First().Split(':').Select(int.Parse).ToArray();
            var scheduledHour = isNight ? gameTimeParts[0] + 12 : gameTimeParts[0];
            var now = DateTime.Now;
            var scheduledYear = now.Month < gameDateParts[0] ? now.Year : now.Year + 1;
            var scheduledDateTime = new DateTime(scheduledYear, gameDateParts[0], gameDateParts[1], scheduledHour, gameTimeParts[1], 0);
            return scheduledDateTime;
        }

		private static string CleanString(string source)
		{
			return WebUtility.HtmlDecode(source.Replace("\n", "").Replace("\r", "").Trim());
		}
	}
}
