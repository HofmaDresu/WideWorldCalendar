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
                    var reminder = new Intent(context, typeof(NotificationBroadcastReceiver));
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

                var reminder = new Intent(context, typeof(NotificationBroadcastReceiver));
                reminder.PutExtra(Constants.NotificationRequestCodeKey, Constants.NewSeasonNotificationRequestCode);
                reminder.PutExtra(Constants.NotificationTitleKey, "Wide World Sports");
                reminder.PutExtra(Constants.NotificationMessageKey, "A new season is available.");

                var reminderBroadcast = PendingIntent.GetBroadcast(context, Constants.NewSeasonNotificationRequestCode, reminder,
                    PendingIntentFlags.CancelCurrent);
                var alarms = (AlarmManager)context.GetSystemService(Context.AlarmService);

                var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var notificationTimeMilliseconds = DateTime.Now.Date.AddHours(9).ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
                alarms.SetExact(AlarmType.RtcWakeup,
                    (long)notificationTimeMilliseconds,
                    reminderBroadcast);
            }
        }

        private static async Task UpdateSchedulesIfNeeded(Context context, Data dataInstance)
        {
            var scheduleFetcher = GetScheduleFetcher();

            var teams = dataInstance.GetMyCurrentTeams();
            var dataFetchTasks = teams.Select(team => scheduleFetcher.GetTeamSchedule(team.Id)).ToList();
            try
            {
                await Task.WhenAll(dataFetchTasks);
            }
            catch (Exception)
            {
                //Eat exception
                return;
            }

            foreach (var task in dataFetchTasks)
            {
                var serverGames = task.Result;
                var teamId = serverGames.FirstOrDefault()?.MyTeam?.Id;
                var teamName= serverGames.FirstOrDefault()?.MyTeam?.Name;
                if (!teamId.HasValue) continue;

                var currentGames = dataInstance.GetGames(teamId.Value);


                if (dataInstance.ShowScheduleChangedNotifications() && dataInstance.ScheduleHasChanged(currentGames, serverGames))
                {
                    var reminder = new Intent(context, typeof(NotificationBroadcastReceiver));
                    reminder.PutExtra(Constants.NotificationRequestCodeKey, teamId.Value);
                    reminder.PutExtra(Constants.NotificationTitleKey, "Team Schedule Changed");
                    reminder.PutExtra(Constants.NotificationMessageKey, $"The schedule for {teamName} has been updated.");

                    var reminderBroadcast = PendingIntent.GetBroadcast(context, teamId.Value, reminder,
                        PendingIntentFlags.CancelCurrent);
                    var alarms = (AlarmManager)context.GetSystemService(Context.AlarmService);

                    var dtBasis = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    var notificationTimeMilliseconds = DateTime.Now.Date.AddHours(9).ToUniversalTime().Subtract(dtBasis).TotalMilliseconds;
                    alarms.SetExact(AlarmType.RtcWakeup,
                        (long)notificationTimeMilliseconds,
                        reminderBroadcast);
                }

                dataInstance.DeleteGames(teamId.Value);
                foreach (var gameInfo in serverGames)
                {
                    var game = DataConverter.ConvertDtoToPersistence(gameInfo);
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