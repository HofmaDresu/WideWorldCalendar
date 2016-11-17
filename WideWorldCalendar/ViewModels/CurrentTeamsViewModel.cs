using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
	public class CurrentTeamsViewModel : BaseViewModel
	{
        public CurrentTeamsViewModel()
	    {
            AddTeamsCommand = new Command(_ =>
	        {
	            
	        });
        }

	    public ObservableRangeCollection<Team> Teams { get; } = new ObservableRangeCollection<Team>();

        public ICommand AddTeamsCommand { protected set; get; }

    }
}
