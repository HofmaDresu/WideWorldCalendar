using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return;
            }
            var seasons = scheduleFetcher.GetSeasons(scheduleHtml);

            if (seasons.Any(dataInstance.IsNewSeason))
            {
                dataInstance.UpdateSeasons(seasons);

                var reminder = new Intent(context, typeof(BasicNotificationBroadcastReceiver));
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

            var teams = dataInstance.GetRecentAndCurrentTeams();
            var dataFetchTasks = teams.Select(team => scheduleFetcher.GetTeamSchedule(team.Id)).ToList();
            try
            {
                await Task.WhenAll(dataFetchTasks);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "teamIds", string.Join(", ", teams.Select(team => team.Id)) } });
                return;
            }

            var serverGames = new List<Game>();
            foreach (var task in dataFetchTasks)
            {
                var teamGames = task.Result;
                var teamId = teamGames.FirstOrDefault()?.MyTeam?.Id;
                var teamName= teamGames.FirstOrDefault()?.MyTeam?.Name;
                if (!teamId.HasValue) continue;

                var currentGames = dataInstance.GetGames(teamId.Value);


                if (dataInstance.ShowScheduleChangedNotifications() && dataInstance.ScheduleHasChanged(currentGames, teamGames))
                {
                    var reminder = new Intent(context, typeof(BasicNotificationBroadcastReceiver));
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
                
                serverGames.AddRange(teamGames);
            }
            dataInstance.UpdateSchedules(serverGames.Select(DataConverter.ConvertDtoToPersistence).ToList());
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