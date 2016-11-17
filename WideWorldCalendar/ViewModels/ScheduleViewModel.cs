using System;
using System.Linq;
using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
	{
	    private readonly INavigation _navigation;

        public ScheduleViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SaveCommand = new Command(_ =>
	        {
	            var data = Data.GetInstance();
                var localNotification = DependencyService.Get<ILocalNotification>();

                var myTeamInfo = Games.First().MyTeam;
	            var myTeam = new Persistence.Models.MyTeam
	            {
                    TeamName = myTeamInfo.Name,
                    TeamColor = myTeamInfo.Color,
                    Division = myTeamInfo.Division,
                    LastGameDateTime = Games.OrderBy(g => g.ScheduledDateTime).Last().ScheduledDateTime
	            };

	            data.InsertMyTeam(myTeam);

	            foreach (var gameInfo in Games)
	            {
	                var game = new Persistence.Models.Game
	                {
	                    Field = gameInfo.Field,
                        IsHomeGame = gameInfo.IsHomeGame,
                        MyTeamId = myTeam.Id,
                        ScheduledDateTime = gameInfo.ScheduledDateTime,
                        OpposingTeam = new Persistence.Models.OpposingTeam
                        {
                            TeamName = gameInfo.OpposingTeam.Name,
                            TeamColor = gameInfo.OpposingTeam.Color
                        }
	                };
	                data.InsertGame(game);

                    //TODO: Handle double headers
                    //TODO: ask if user wants notifications
	                var notificationTitle = "Soccer Tonight!";
	                var notificationMessage = $"{myTeam.TeamName} @ {game.ScheduledDateTime.ToString("t")}";
	                if (game.ScheduledDateTime.Date > DateTime.Now.Date)
	                {
                        localNotification.ScheduleGameNotification(notificationTitle, notificationMessage, game.Id, game.ScheduledDateTime.Date.AddHours(9));
                    }
#if DEBUG
                    if (game.ScheduledDateTime.Date == DateTime.Now.Date)
                    {
                        localNotification.ScheduleGameNotification(notificationTitle, notificationMessage, game.Id, DateTime.Now.AddMinutes(1));
                    }
#endif
                }

	            _navigation.PopToRootAsync(true);
	        });
        }


	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand SaveCommand { protected set; get; }

    }
}
