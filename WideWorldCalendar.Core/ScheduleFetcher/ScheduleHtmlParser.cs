using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using WideWorldCalendar.Utilities;
using Xamarin.Forms;
using System.Text.RegularExpressions;

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

            var gameSections = scheduleSection.Split("list-group-item ").Where(s => s.Contains("col-lg-6 col-12")).ToList();

            return gameSections.Select(section =>
            {
                var dateTimeSection = section.Split("flex-shrink-0").Last().Split("mr-4").First();
                var gamesInfoSection = section.Split("flex-grow-1").Last().Split("</small>").First();

                var game = new Game
                {
                    ScheduledDateTime = GetScheduledDateTime(dateTimeSection),
                    Field = CleanString(gamesInfoSection.Split("<small>").Last()),
                };

                SetTeamInfo(teamId, gamesInfoSection, game);
                return game;
            });

        }

        public static void SetTeamInfo(int teamId, string teamsInfoSection, Game game)
        {
            var cleanedTeamsInfoSection = teamsInfoSection.Split("</h6>").Last();

            var teamRows = cleanedTeamsInfoSection.Split("justify-content-between").ToList();
            for (int i = 0; i < teamRows.Count; i++)
            {
                var row = teamRows[i];
                var teamIdString = row.Split("teamid=").Last().Split("\">").First();
                if (!int.TryParse(teamIdString, out int currentTeamId)) continue;

                var teamColumns = row.Split("</div>").Where(s => s.Contains("<div")).ToArray();
                var teamNameColumn = teamColumns[0];
                var scoreColumn = teamColumns[1];
                var hasScore = int.TryParse(scoreColumn.Split('>').Last(), out int score);

                var team = new Team
                {
                    Id = currentTeamId,
                    Name = teamNameColumn.Split("teamid=").Last().Split('>')[1].Split('<')[0],
                };

                if (currentTeamId == teamId)
                {
                    game.IsHomeGame = teamNameColumn.Contains("fa-home");
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
            var gameScheduleSections = section.Split("\"list-group-item-heading\">").Last().Split("</div>").ToList();

            var gameDateStrings = gameScheduleSections[0].Trim().Split(" ");

            var gameMonthString = gameDateStrings[0];
            var gameMonth = GetMonthNumberFromString(gameMonthString);
            var intRegex = new Regex(@"\d+");
            var gameDay = int.Parse(intRegex.Match(gameDateStrings[1]).Value);

            var gameTimeString = gameScheduleSections[1];

            var isNight = gameTimeString.Contains("pm");
            var gameTimeParts = gameTimeString.Split('>').Last().Split(' ')[1].Split(':').Select(int.Parse).ToArray();
            var gameHour= gameTimeParts[0];
            var gameMinute = gameTimeParts[1];
            var scheduledHour = isNight ? gameHour + 12 : gameHour;

            var now = DateTime.Now;
            var scheduledYear = CalculateYear(now, gameMonth);
            var scheduledDateTime = new DateTime(scheduledYear, gameMonth, gameDay, scheduledHour, gameMinute, 0);
            return scheduledDateTime;
        }

        private static int GetMonthNumberFromString(string gameMonthString)
        {
            switch (gameMonthString)
            {
                case "Jan":
                    return 1;
                case "Feb":
                    return 2;
                case "Mar":
                    return 3;
                case "Apr":
                    return 4;
                case "May":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Oct":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;
                default:
                    throw new ArgumentException(gameMonthString);
            }
        }

        private static int CalculateYear(DateTime now, int scheduledMonth)
        {
            if (now.Month >= 9 && scheduledMonth <= 3)
            {
                return now.Year + 1;
            }
            else if (now.Month <= 3 && scheduledMonth >= 9)
            {
                return now.Year - 1;
            }
            return now.Year;
        }

		private static string CleanString(string source)
		{
			return WebUtility.HtmlDecode(source.Replace("\n", "").Replace("\r", "").Trim());
		}

        public static Color GetTeamColor(string html)
        {
            try
            {
                var colorSection = html.Split("<div class=\"form-group\"><input type=\"text\" name=\"color\" ")[1].Split("/div")[0];
                var colorHex = colorSection.Split("value=\"")[1].Split("/")[0].Split("\"")[0];
                return colorHex.StartsWith("#") ? Color.FromHex(colorHex) : Color.Transparent;
            }
            catch (Exception)
            {
                return Color.Transparent;
            }
        }
	}
}
