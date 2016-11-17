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
	    private INavigation _navigation;

        public ScheduleViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SaveCommand = new Command(_ =>
	        {
	            var data = Data.GetInstance();

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
	            }

	            _navigation.PopToRootAsync(true);
	        });
        }


	    public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand SaveCommand { protected set; get; }

    }
}
