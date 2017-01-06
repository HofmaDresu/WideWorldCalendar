using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

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

        public ObservableCollection<Grouping<string, MyTeam>> Teams { get; } = new ObservableCollection<Grouping<string, MyTeam>>();

        public ICommand AddTeamsCommand { protected set; get; }

	    public void RefreshTeams()
	    {
            Teams.Clear();
            Teams.Add(new Grouping<string, MyTeam>("Current Teams", Data.GetInstance().GetMyCurrentTeams()));
            var pastTeams = Data.GetInstance().GetMyPastTeams().OrderByDescending(t => t.LastGameDateTime);
            if (pastTeams.Any())
            {
                Teams.Add(new Grouping<string, MyTeam>("Previous Teams", pastTeams));
            }
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
