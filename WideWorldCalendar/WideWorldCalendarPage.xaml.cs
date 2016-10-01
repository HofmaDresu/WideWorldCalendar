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
			var scheduleTypes = await scheduleFetcher.GetScheduleTypes(seasons.Last());


			var bar = 1;
		}
	}
}
