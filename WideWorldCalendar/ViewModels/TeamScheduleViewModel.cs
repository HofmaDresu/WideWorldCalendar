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
        }

        public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();
    }
}
