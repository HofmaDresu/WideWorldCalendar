using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
	public class CurrentTeamsViewModel : BaseViewModel
	{
	    private readonly INavigation _navigation;

        public CurrentTeamsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AddTeamsCommand = new Command(async _ =>
            {
                await _navigation.PushAsync(new SelectSchedulePage());
            });
        }

	    public ObservableRangeCollection<Team> Teams { get; } = new ObservableRangeCollection<Team>();

        public ICommand AddTeamsCommand { protected set; get; }

    }
}
