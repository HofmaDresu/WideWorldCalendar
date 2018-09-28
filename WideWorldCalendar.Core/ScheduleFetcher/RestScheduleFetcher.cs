using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class RestScheduleFetcher : IScheduleFetcher
    {
        private const string BaseAddress = "https://apps.dashplatform.com";
        private const string BaseScheduleUrl = BaseAddress + "/dash/index.php?Action=League%2Fstandings&_method=GET&noheader=&facilityID=1&programID=0";
        private const string SeasonScheduleParameter = "SeasonID{0}";
        private const string BaseTeamUrl = BaseAddress + "/dash/index.php?Action=Team/index&company=wideworldsports&teamid={0}";

        public RestScheduleFetcher()
        {
            handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(30) };
        }

        private readonly CookieContainer cookieContainer = new CookieContainer();
        private readonly HttpClientHandler handler;
        private readonly HttpClient client;
        private CookieCollection cookies;

        public async Task<List<NavigationOption>> GetSeasons()
		{
            await client.GetStringAsync(BaseScheduleUrl);
            cookies = cookieContainer.GetCookies(new Uri(BaseScheduleUrl));

            var seasonsHtml = await client.GetStringAsync(BaseScheduleUrl);


            return ScheduleHtmlParser.GetSeasons(seasonsHtml).ToList();
        }

		public async Task<Dictionary<string, List<NavigationOption>>> GetLeagues(int seasonId)
		{
            throw new NotImplementedException();
		}

		public async Task<List<Game>> GetTeamSchedule(int teamId)
		{
			var divisionReportHtml = await client.GetStringAsync(string.Format(BaseTeamUrl, teamId));
			return ScheduleHtmlParser.GetTeamSchedule(teamId, divisionReportHtml).ToList();
		}
	}
}
