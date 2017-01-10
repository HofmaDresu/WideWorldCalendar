using MvvmHelpers;
using System.Windows.Input;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using Xamarin.Forms;

namespace WideWorldCalendar.ViewModels
{
    public class TeamScheduleViewModel : BaseViewModel
    {
        public TeamScheduleViewModel(int myTeamId)
        {
            Games.AddRange(Data.GetInstance().GetGames(myTeamId));

            RefreshGamesCommand = new Command(_ =>
            {

            });
        }

        public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public ICommand RefreshGamesCommand { get; set; }
    }
}
