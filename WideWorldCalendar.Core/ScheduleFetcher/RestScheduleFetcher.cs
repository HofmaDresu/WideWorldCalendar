using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class RestScheduleFetcher : IScheduleFetcher
    {
        private const string BaseScheduleUrl = "https://apps.dashplatform.com/dash/index.php?Action=League%2Fstandings&_method=GET&noheader=&facilityID=1&programID=0";
        private const string SeasonScheduleParameter = "SeasonID{0}";
        private const string BaseTeamUrl = "https://apps.dashplatform.com/dash/index.php?Action=Team/index&company=wideworldsports&teamid={0}"

        public async Task<List<NavigationOption>> GetSeasons()
		{
			return ScheduleHtmlParser.GetSeasons(await GetClient().GetStringAsync(BaseScheduleUrl)).ToList();
        }

		public async Task<Dictionary<string, List<NavigationOption>>> GetLeagues(int seasonId)
		{
            throw new NotImplementedException();
		}

		public async Task<List<Game>> GetTeamSchedule(int teamId)
		{
			var divisionReportHtml = await GetClient().GetStringAsync(string.Format(BaseTeamUrl, teamId));
			return ScheduleHtmlParser.GetTeamSchedule(teamId, divisionReportHtml).ToList();
		}

	    private HttpClient GetClient()
	    {
	        return new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
	    }
	}
}
