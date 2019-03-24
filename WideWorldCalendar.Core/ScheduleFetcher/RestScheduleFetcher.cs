using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WideWorldCalendar.Persistence;
using Xamarin.Forms;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class RestScheduleFetcher : IScheduleFetcher
    {
        private const string BaseAddress = "https://apps.dashplatform.com";
        private const string BaseScheduleUrl = BaseAddress + "/dash/index.php?Action=League%2Fstandings&_method=GET&noheader=&facilityID=1&programID=0&company=wideworldsports";
        private const string SeasonScheduleParameter = "seasonID={0}";
        private const string BaseTeamUrl = BaseAddress + "/dash/index.php?Action=Team/index&company=wideworldsports&teamid={0}";

        public RestScheduleFetcher()
        {
            if (cookieContainer.Count == 0)
            {
                cookieContainer.Add(new Uri(BaseAddress), new Cookie("mysam_company", "wideworldsports"));
            }
            handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
#if DEBUG
                Proxy = DependencyService.Get<IProxyService>().Proxy,
#endif
            };
            client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(30) };
        }

        private readonly CookieContainer cookieContainer = new CookieContainer();
        private readonly HttpClientHandler handler;
        private readonly HttpClient client;

        public async Task<List<NavigationOption>> GetSeasons()
		{
            var seasonsHtml = await client.GetStringAsync(BaseScheduleUrl);

            return ScheduleHtmlParser.GetSeasons(seasonsHtml).ToList();
        }

		public async Task<Dictionary<string, List<NavigationOption>>> GetLeagues(int seasonId)
        {
            var seasonHtml = await client.GetStringAsync($"{BaseScheduleUrl}&{string.Format(SeasonScheduleParameter, seasonId)}");
            return ScheduleHtmlParser.GetLeagues(seasonHtml);
        }

		public async Task<List<Game>> GetTeamSchedule(int teamId)
        {
            var data = Data.GetInstance();
            var divisionReportHtml = await client.GetStringAsync(string.Format(BaseTeamUrl, teamId));
            var games = ScheduleHtmlParser.GetTeamSchedule(teamId, divisionReportHtml).ToList();

            foreach (var game in games)
            {
                var dbMyTeamColor = data.GetTeamColor(game.MyTeam.Id);
                if (!(dbMyTeamColor is null))
                {
                    game.MyTeam.Color = dbMyTeamColor.Color;
                }
                else
                {
                    var color = ScheduleHtmlParser.GetTeamColor(divisionReportHtml);
                    game.MyTeam.Color = color;
                    data.InsertTeamColor(new Persistence.Models.TeamColor(game.MyTeam.Id, color.R, color.G, color.B, color.A));
                }

                var dbOpposingColor = data.GetTeamColor(game.OpposingTeam.Id);
                if (!(dbOpposingColor is null))
                {
                    game.OpposingTeam.Color = dbOpposingColor.Color;
                }
                else
                {
                    var opposingTeamDivisionReportHtml = await client.GetStringAsync(string.Format(BaseTeamUrl, game.OpposingTeam.Id));

                    var color = ScheduleHtmlParser.GetTeamColor(opposingTeamDivisionReportHtml);
                    game.OpposingTeam.Color = color;
                    data.InsertTeamColor(new Persistence.Models.TeamColor(game.OpposingTeam.Id, color.R, color.G, color.B, color.A));
                }
            }

            return games;
		}
	}
}
