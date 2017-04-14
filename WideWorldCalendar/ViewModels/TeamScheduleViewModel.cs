using MvvmHelpers;
using System.Windows.Input;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using System.Linq;
using Xamarin.Forms;
using System;

namespace WideWorldCalendar.ViewModels
{
    public class TeamScheduleViewModel : BaseViewModel
    {
        public TeamScheduleViewModel(int myTeamId)
        {
            Games.AddRange(Data.GetInstance().GetGames(myTeamId));
        }

        public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public Game InitialDisplayGame => Games.FirstOrDefault(g => DateTime.Now < g.ScheduledDateTime.AddHours(1)) ?? Games.First();
    }
}
