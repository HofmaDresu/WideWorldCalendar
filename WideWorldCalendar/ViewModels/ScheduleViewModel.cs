using MvvmHelpers;
using WideWorldCalendar.ScheduleFetcher;

namespace WideWorldCalendar.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
	{
	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();
	}
}
