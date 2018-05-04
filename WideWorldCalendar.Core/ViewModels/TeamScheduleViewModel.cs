using MvvmHelpers;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using System.Linq;
using System;

namespace WideWorldCalendar.ViewModels
{
    public class TeamScheduleViewModel : BaseViewModel
    {
        public TeamScheduleViewModel(int myTeamId)
        {
            var myTeam = Data.GetInstance().GetTeam(myTeamId);

            MyTeamName = myTeam.TeamName;

            Games.AddRange(Data.GetInstance().GetGames(myTeamId));
        }

        public ObservableRangeCollection<Game> Games { get; } = new ObservableRangeCollection<Game>();

        public Game InitialDisplayGame => Games.FirstOrDefault(g => DateTime.Now < g.ScheduledDateTime.AddHours(1)) ?? Games.First();

        public String MyTeamName { get; set; }
    }
}
