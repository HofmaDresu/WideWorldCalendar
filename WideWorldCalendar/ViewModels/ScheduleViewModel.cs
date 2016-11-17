using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
	{
        public ScheduleViewModel()
	    {
	        SaveCommand = new Command(_ =>
	        {
	            
	        });
        }


	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand SaveCommand { protected set; get; }

    }
}
