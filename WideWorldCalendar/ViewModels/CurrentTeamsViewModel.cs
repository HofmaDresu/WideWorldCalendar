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
            var currentTeams = Data.GetInstance().GetMyCurrentTeams().Select(CalculateRecord);
            Teams.Add(new Grouping<string, MyTeam>("Current Teams", currentTeams));
            var pastTeams = Data.GetInstance().GetMyPastTeams().OrderByDescending(t => t.LastGameDateTime).Select(CalculateRecord);
            if (pastTeams.Any())
            {
                Teams.Add(new Grouping<string, MyTeam>("Previous Teams", pastTeams));
            }
        }

        private MyTeam CalculateRecord(MyTeam t)
        {
            var games = Data.GetInstance().GetGames(t.Id);
            var winCount = games.Where(g => g.WinLoss == Constants.Win).Count();
            var lossCount = games.Where(g => g.WinLoss == Constants.Loss).Count();
            var tieCount = games.Where(g => g.WinLoss == Constants.Tie).Count();
            var team = new MyTeam
            {
                Division = t.Division,
                Id = t.Id,
                LastGameDateTime = t.LastGameDateTime,
                // Let user know record info is unavailable for seasons that predate this feature
                Record = $"{winCount} - {lossCount} - {tieCount}" + (t.LastGameDateTime < new System.DateTime(2017, 01, 06) ? " (record unavailable)" : string.Empty),
                SendGameTimeReminders = t.SendGameTimeReminders,
                TeamColor = t.TeamColor,
                TeamName = t.TeamName
            };
            return team;
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
