using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WideWorldCalendar.Utilities
{
    public static class DataConverter
    {
        public static Persistence.Models.Game ConvertDtoToPersistence(ScheduleFetcher.Game dto)
        {
            return new Persistence.Models.Game
            {
                Field = dto.Field,
                IsHomeGame = dto.IsHomeGame,
                MyTeamId = dto.MyTeam.Id,
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

        public static Persistence.Models.MyTeam ConvertDtoToPersistence(ScheduleFetcher.Team dto, DateTime lastGameDateTime, bool sendGameTimeReminders)
        {
            return new Persistence.Models.MyTeam
            {
                Id = dto.Id,
                TeamName = dto.Name,
                TeamColor = dto.Color,
                Division = dto.Division,
                LastGameDateTime = lastGameDateTime,
                SendGameTimeReminders = sendGameTimeReminders
            };
        }
    }
}
