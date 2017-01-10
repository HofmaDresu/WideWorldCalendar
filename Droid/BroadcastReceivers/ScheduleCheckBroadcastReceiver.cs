using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using WideWorldCalendar.Droid.Utilities;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.ScheduleFetcher;
using WideWorldCalendar.Utilities;
using Xamarin.Forms;
using Game = WideWorldCalendar.ScheduleFetcher.Game;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    public class ScheduleCheckBroadcastReceiver : BroadcastReceiver
    {
        public override async void OnReceive(Context context, Intent intent)
        {
            var dataInstance = Data.GetInstance(new SQLite_Android().GetConnection());

            if (dataInstance.ShowGameNotifications())
            {
                var notificationPreferences = dataInstance.GetGameNotificationPreferences();
                var gameCheckDate = DateTime.Now.Date.AddDays(notificationPreferences.Day == DayPreference.TheDayOfTheGame ? 0 : 1);

                int preferredHour = TimeConversionUtil.ConvertHourPreferenceTo24Hour(notificationPreferences);

                var notificationTime = DateTime.Now.Date.AddHours(preferredHour);

                foreach (var notification in dataInstance.GetNotificationsForDay(gameCheckDate))
                {
                    var reminder = new Intent(context, typeof(GameNotificationBroadcastReceiver));
                    reminder.PutExtra(Constants.NotificationRequestCodeKey, notification.TeamId);
                    reminder.PutExtra(Constants.NotificationTitleKey, notification.Title);
                    reminder.PutExtra(Constants.NotificationMessageKey, notification.Message);

                    var reminderBroadcast = PendingIntent.GetBroadcast(context, notification.TeamId, reminder,
                        PendingIntentFlags.CancelCurrent);
                    var alarms = (AlarmManager)context.GetSystemService(Context.AlarmService);

                    var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    var notificationTimeMilliseconds = notificationTime.ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
                    alarms.SetExact(AlarmType.RtcWakeup,
                        (long)notificationTimeMilliseconds,
                        reminderBroadcast);
                }
            }

            await UpdateSchedulesIfNeeded(context, dataInstance);
            
            if (dataInstance.ShowNewSeasonAvailableNotifications())
            {
                await CheckForNewSeason(context, dataInstance);
            }

            new LocalNotification_Android().ScheduleGameNotification(context);
        }

        private static async Task CheckForNewSeason(Context context, Data dataInstance)
        {
            IScheduleFetcher scheduleFetcher = GetScheduleFetcher();
            string scheduleHtml;
            try
            {
                scheduleHtml = await scheduleFetcher.GetSchedulesPage();
            }
            catch (Exception)
            {
                //Eat exception
                return;
            }
            var seasons = scheduleFetcher.GetSeasons(scheduleHtml);

            if (seasons.Any(dataInstance.IsNewSeason))
            {
                dataInstance.UpdateSeasons(seasons);
                LocalNotification_Android.CreateNotification(context, Constants.NewSeasonNotificationRequestCode, "Wide World Sports",
                    "A new season is available.");
            }
        }

        private static async Task UpdateSchedulesIfNeeded(Context context, Data dataInstance)
        {
            var scheduleFetcher = GetScheduleFetcher();
            foreach (var team in dataInstance.GetMyCurrentTeams())
            {
                var currentGames = dataInstance.GetGames(team.Id);
                List<Game> serverGames;
                try
                {
                    serverGames = await scheduleFetcher.GetTeamSchedule(team.Id);
                }
                catch (Exception)
                {
                    //Eat exception
                    return;
                }


                if (dataInstance.ShowScheduleChangedNotifications() && dataInstance.ScheduleHasChanged(currentGames, serverGames))
                {
                    LocalNotification_Android.CreateNotification(context, team.Id, "Team Schedule Changed",
                        $"The schedule for {team.TeamName} has been updated.");
                }

                dataInstance.DeleteGames(team.Id);
                foreach (var gameInfo in serverGames)
                {
                    var game = new Persistence.Models.Game
                    {
                        Field = gameInfo.Field,
                        IsHomeGame = gameInfo.IsHomeGame,
                        MyTeamId = team.Id,
                        ScheduledDateTime = gameInfo.ScheduledDateTime,
                        OpposingTeam = new OpposingTeam
                        {
                            TeamName = gameInfo.OpposingTeam.Name,
                            TeamColor = gameInfo.OpposingTeam.Color
                        },
                        MyTeamScore = gameInfo.MyTeamScore,
                        OpposingTeamScore = gameInfo.OpposingTeamScore
                    };
                    dataInstance.InsertGame(game);
                }
            }
        }

        private static IScheduleFetcher GetScheduleFetcher()
        {
            if (Forms.IsInitialized)
            {
                return DependencyService.Get<IScheduleFetcher>();
            }
            else
            {
#if UITEST
                return new MockScheduleFetcher();
#else
                return new RestScheduleFetcher();
#endif
            }

        }
    }
}