using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

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
			var foo = await scheduleFetcher.GetSeasons();



			var bar = 1;
		}
	}
}
