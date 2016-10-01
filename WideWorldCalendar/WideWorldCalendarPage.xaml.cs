using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;
using System.Linq;

namespace WideWorldCalendar
{
	public partial class WideWorldCalendarPage : ContentPage
	{
		public WideWorldCalendarPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var scheduleFetcher = new MockScheduleFetcher();
			var seasons = await scheduleFetcher.GetSeasons();
			var scheduleGroupings = await scheduleFetcher.GetScheduleGroupings(seasons.Last());
			var scheduleTypes = await scheduleFetcher.GetDivisions(seasons.Last(), scheduleGroupings.Last());
			var teams = await scheduleFetcher.GetTeams(scheduleTypes.Last().Id);

			var bar = 1;
		}
	}
}
