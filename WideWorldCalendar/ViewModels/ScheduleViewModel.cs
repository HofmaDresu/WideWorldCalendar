using MvvmHelpers;
using WideWorldCalendar.ScheduleFetcher;

namespace WideWorldCalendar.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
	{
		private readonly ObservableRangeCollection<Game> _games = new ObservableRangeCollection<Game>();
		public ObservableRangeCollection<Game> Games
		{
			get { return _games; }
		}

	}
}
