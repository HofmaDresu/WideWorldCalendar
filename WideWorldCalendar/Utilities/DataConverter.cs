using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WideWorldCalendar.Utilities
{
    public static class DataConverter
    {
        public static Persistence.Models.Game ConvertDtoToPersistence(ScheduleFetcher.Game dto, Persistence.Models.MyTeam myTeam)
        {
            return new Persistence.Models.Game
            {
                Field = dto.Field,
                IsHomeGame = dto.IsHomeGame,
                MyTeamId = myTeam.Id,
                ScheduledDateTime = dto.ScheduledDateTime,
                OpposingTeam = new Persistence.Models.OpposingTeam
                {
                    TeamName = dto.OpposingTeam.Name,
                    TeamColor = dto.OpposingTeam.Color
                },
                MyTeamScore = dto.MyTeamScore,
                OpposingTeamScore = dto.OpposingTeamScore
            };
        }
    }
}
