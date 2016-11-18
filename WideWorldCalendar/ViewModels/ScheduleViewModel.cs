using System;
using System.Collections.Generic;
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
            var gameDays = new Dictionary<DateTime, List<Persistence.Models.Game>>();
            _navigation = navigation;
            SaveCommand = new Command(_ =>
	        {
	            var data = Data.GetInstance();
                var localNotification = DependencyService.Get<ILocalNotification>();

                var myTeam = SaveMyTeam(data);

	            foreach (var gameInfo in Games)
	            {
	                var game = SaveGame(gameInfo, myTeam, data);

	                if (gameDays.ContainsKey(game.ScheduledDateTime.Date))
	                {
	                    gameDays[game.ScheduledDateTime.Date].Add(game);
	                }
	                else
	                {
	                    gameDays.Add(game.ScheduledDateTime.Date, new List<Persistence.Models.Game> { game });
	                }
	            }

	            //TODO: ask if user wants notifications
                foreach (var day in gameDays)
                {
                    CreateNotification(myTeam, day.Value, localNotification);
                }

	            _navigation.PopToRootAsync(true);
	        });
        }

	    private static Persistence.Models.Game SaveGame(Game gameInfo, Persistence.Models.MyTeam myTeam, Data data)
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
	        return game;
	    }

	    private Persistence.Models.MyTeam SaveMyTeam(Data data)
	    {
	        var myTeamInfo = Games.First().MyTeam;
	        var myTeam = new Persistence.Models.MyTeam
	        {
	            TeamName = myTeamInfo.Name,
	            TeamColor = myTeamInfo.Color,
	            Division = myTeamInfo.Division,
	            LastGameDateTime = Games.OrderBy(g => g.ScheduledDateTime).Last().ScheduledDateTime
	        };

	        data.InsertMyTeam(myTeam);
	        return myTeam;
	    }

	    private static void CreateNotification(Persistence.Models.MyTeam myTeam, List<Persistence.Models.Game> games, ILocalNotification localNotification)
	    {
	        if (!games.Any()) return;
	        string notificationTitle;

	        switch (games.Count)
	        {
                case 1:
	                notificationTitle = "Game Tonight!";
	                break;
                case 2:
	                notificationTitle = "Double Header Tonight!";
	                break;
                case 3:
	                notificationTitle = "Triple Header Tonight!";
	                break;
                default:
	                notificationTitle = "Games Tonight!";
	                break;
	        }

            var notificationMessage = $"{myTeam.TeamName} @ {string.Join(",", games.Select(g => g.ScheduledDateTime.ToString("t")))}";
	        if (games.First().ScheduledDateTime.Date > DateTime.Now.Date)
	        {
	            localNotification.ScheduleGameNotification(notificationTitle, notificationMessage, games.First().Id,
                    games.First().ScheduledDateTime.Date.AddHours(9));
	        }
#if DEBUG
	        if (games.First().ScheduledDateTime.Date == DateTime.Now.Date)
	        {
	            localNotification.ScheduleGameNotification(notificationTitle, notificationMessage, games.First().Id,
	                DateTime.Now.AddMinutes(1));
	        }
#endif
	    }


	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand SaveCommand { protected set; get; }

    }
}
