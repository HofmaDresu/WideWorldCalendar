using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;
using WideWorldCalendar.Utilities;

namespace WideWorldCalendar.ViewModels
{
	public class ScheduleViewModel : BaseViewModel
	{
	    private readonly INavigation _navigation;

        public ScheduleViewModel(Page page)
        {
            var gameDays = new Dictionary<DateTime, List<Persistence.Models.Game>>();
            _navigation = page.Navigation;
            SaveCommand = new Command(async _ =>
	        {
	            var data = Data.GetInstance();

	            var myTeam = await SaveMyTeam(data, page);
                DependencyService.Get<IUnifiedAnalytics>().CreateAndSendEventOnDefaultTracker(Constants.AnalyticsCategoryUserAction, "Save Team", myTeam.NameAndColor);


                foreach (var gameInfo in Games)
	            {
	                var game = SaveGame(gameInfo, data);

	                if (gameDays.ContainsKey(game.ScheduledDateTime.Date))
	                {
	                    gameDays[game.ScheduledDateTime.Date].Add(game);
	                }
	                else
	                {
	                    gameDays.Add(game.ScheduledDateTime.Date, new List<Persistence.Models.Game> { game });
	                }
	            }

                DependencyService.Get<ILocalNotification>().ScheduleGameNotifications();

                await _navigation.PopToRootAsync(true);
	        });
        }

	    private static Persistence.Models.Game SaveGame(Game gameInfo, Data data)
	    {
            var game = DataConverter.ConvertDtoToPersistence(gameInfo);
            data.InsertGame(game);
	        return game;
	    }

	    private async Task<Persistence.Models.MyTeam> SaveMyTeam(Data data, Page page)
        {
            var myTeamInfo = Games.First().MyTeam;
            var getReminders = await page.DisplayAlert("Game Notifications", $"Would you like game time reminders for {myTeamInfo.Name}?", "Yes", "No");

            var myTeam = DataConverter.ConvertDtoToPersistence(myTeamInfo, Games.OrderBy(g => g.ScheduledDateTime).Last().ScheduledDateTime, getReminders);

	        data.InsertMyTeam(myTeam);
	        return myTeam;
	    }

	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand SaveCommand { protected set; get; }

    }
}
