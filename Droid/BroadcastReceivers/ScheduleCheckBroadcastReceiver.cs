using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms;

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
                foreach (var notification in dataInstance.GetTodaysNotifications())
                {
                    CreateNotification(context, notification.TeamId, notification.Title, notification.Message);
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
            var scheduleHtml = await scheduleFetcher.GetSchedulesPage();
            var seasons = scheduleFetcher.GetSeasons(scheduleHtml);

            if (seasons.Any(s => dataInstance.IsNewSeason(s)))
            {
                dataInstance.UpdateSeasons(seasons);
                CreateNotification(context, Constants.NewSeasonNotificationRequestCode, "Wide World Sports",
                    "A new season is available.");
            }
        }

        private static async Task UpdateSchedulesIfNeeded(Context context, Data dataInstance)
        {
            var scheduleFetcher = new RestScheduleFetcher();
            foreach (var team in dataInstance.GetMyTeams())
            {
                var currentGames = dataInstance.GetGames(team.Id);
                var serverGames = await scheduleFetcher.GetTeamSchedule(team.Id);

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
                    CreateNotification(context, team.Id, "Team Schedule Changed",
                        $"The schedule for {team.TeamName} has been updated.");
                }
            }
        }

        private static void CreateNotification(Context context, int requestCode, string title, string message)
        {
            var builder = new NotificationCompat.Builder(context)
                .SetContentTitle(title)
                .SetContentText(message);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                builder
                    .SetPriority((int) NotificationPriority.Low)
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetCategory("reminder")
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else if ((int) Build.VERSION.SdkInt >= 20)
            {
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
            }
            else
            {
                // Disable obsolete warning 'cause this was how you do it pre-20
#pragma warning disable 618
                builder
                    .SetSmallIcon(Resource.Drawable.ic_launcher);
#pragma warning restore 618
            }

            var notification = builder.Build();

            notification.Flags |= NotificationFlags.AutoCancel;

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager?.Notify(requestCode, notification);
        }
    }
}