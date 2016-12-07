using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using WideWorldCalendar.Droid.Utilities;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.Persistence.Models;
using WideWorldCalendar.ScheduleFetcher;
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
                var preferences = dataInstance.GetGameNotificationPreferences();
                var gameCheckDate = DateTime.Now.Date.AddDays(preferences.Day == DayPreference.GameDay ? 0 : 1);
                var notificationTime = DateTime.Now.Date.AddHours(preferences.Meridian == Meridian.Am
                                            ? preferences.Hour
                                            : preferences.Hour + 12);

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

            if (dataInstance.ShowScheduleChangedNotifications())
            {
                await UpdateSchedulesIfNeeded(context, dataInstance);
            }
            
            if (dataInstance.ShowNewSeasonAvailableNotifications())
            {
                await CheckForNewSeason(context, dataInstance);
            }

            new LocalNotification_Android().ScheduleGameNotification(context);
        }

        private static async Task CheckForNewSeason(Context context, Data dataInstance)
        {
            var scheduleFetcher = new RestScheduleFetcher();
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
            var scheduleFetcher = new RestScheduleFetcher();
            foreach (var team in dataInstance.GetMyTeams())
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

                if (currentGames.Any(
                    g =>
                        !serverGames.Any(
                            sg =>
                                g.IsHomeGame == sg.IsHomeGame && g.ScheduledDateTime == sg.ScheduledDateTime &&
                                g.Field == sg.Field
                                && g.MyTeamId == sg.MyTeam.Id && g.OpposingTeam.TeamName == sg.OpposingTeam.Name &&
                                g.OpposingTeam.TeamColor == sg.OpposingTeam.Color))
                    ||
                    serverGames.Any(
                        sg =>
                            !currentGames.Any(
                                g =>
                                    g.IsHomeGame == sg.IsHomeGame && g.ScheduledDateTime == sg.ScheduledDateTime &&
                                    g.Field == sg.Field
                                    && g.MyTeamId == sg.MyTeam.Id && g.OpposingTeam.TeamName == sg.OpposingTeam.Name &&
                                    g.OpposingTeam.TeamColor == sg.OpposingTeam.Color)))
                {
                    dataInstance.DeleteGames(team.Id);
                    foreach (var gameInfo in serverGames)
                    {
                        var game = new Persistence.Models.Game
                        {
                            Field = gameInfo.Field,
                            IsHomeGame = gameInfo.IsHomeGame,
                            MyTeamId = team.Id,
                            ScheduledDateTime = gameInfo.ScheduledDateTime,
                            OpposingTeam = new Persistence.Models.OpposingTeam
                            {
                                TeamName = gameInfo.OpposingTeam.Name,
                                TeamColor = gameInfo.OpposingTeam.Color
                            }
                        };
                        dataInstance.InsertGame(game);
                    }
                    LocalNotification_Android.CreateNotification(context, team.Id, "Team Schedule Changed",
                        $"The schedule for {team.TeamName} has been updated.");
                }
            }
        }
    }
}