using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using WideWorldCalendar.UtilityInterfaces;

namespace WideWorldCalendar.ViewModels
{
    public class CurrentTeamsViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly Data _data;

        public CurrentTeamsViewModel(INavigation navigation, Page page)
        {
            _data = Data.GetInstance();
            _navigation = navigation;
            AddTeamsCommand = new Command(async _ =>
            {
                await _navigation.PushAsync(new SelectSchedulePage());
            });
            EditTeamCommand = new Command<MyTeam>(async t =>
            {
                var getReminders = await page.DisplayAlert("Game Notifications", $"Would you like game time reminders for {t.TeamName}?", "Yes", "No");

                if (getReminders && !_data.ShowGameNotifications())
                {
                    var activateReminders = await page.DisplayAlert("Game Notifications", $"Game notifications are turned off in settings. Would you like to turn them on?", "Yes", "No");
                    if (activateReminders)
                    {
                        _data.SetShowGameNotifications(true);
                        DependencyService.Get<ILocalNotification>().ScheduleGameNotifications();
                    }
                }

                t.SendGameTimeReminders = getReminders;
                _data.UpdateMyTeam(t);
            });
            DeleteTeamCommand = new Command<MyTeam>(async t =>
            {
                var confirmDelete = await page.DisplayAlert("Confirm Delete", $"Delete {t.TeamName}?", "Yes", "No");
                if (confirmDelete)
                {
                    _data.DeleteMyTeam(t.Id);
                    RefreshTeams();
                }
            });
        }

        public ObservableCollection<Grouping<string, MyTeam>> Teams { get; } = new ObservableCollection<Grouping<string, MyTeam>>();

        public ICommand AddTeamsCommand { protected set; get; }
        public ICommand EditTeamCommand { protected set; get; }
        public ICommand DeleteTeamCommand { protected set; get; }

        public void RefreshTeams()
	    {
            Teams.Clear();
            var currentTeams = _data.GetMyCurrentTeams().Select(CalculateRecord);
            Teams.Add(new Grouping<string, MyTeam>("Current Teams", currentTeams));
            var pastTeams = _data.GetMyPastTeams().OrderByDescending(t => t.LastGameDateTime).Select(CalculateRecord);
            if (pastTeams.Any())
            {
                Teams.Add(new Grouping<string, MyTeam>("Previous Teams", pastTeams));
            }
        }

        private MyTeam CalculateRecord(MyTeam t)
        {
            var games = _data.GetGames(t.Id);
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
