using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.Views;
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

	    public ObservableRangeCollection<MyTeam> Teams { get; } = new ObservableRangeCollection<MyTeam>();

        public ICommand AddTeamsCommand { protected set; get; }

	    public void RefreshTeams()
	    {
            Teams.ReplaceRange(Data.GetInstance().GetMyCurrentTeams());
        }

	    private MyTeam _selectedTeam;
	    public MyTeam SelectedTeam
	    {
	        get { return _selectedTeam; }
	        set
	        {
	            if (value == null) return;
	            _navigation.PushAsync(new TeamSchedulePage(value));

                SetProperty(ref _selectedTeam, value);
                SetProperty(ref _selectedTeam, null);
	        }
	    }
    }
}
