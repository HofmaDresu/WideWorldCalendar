using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using WideWorldCalendar.Persistence;

namespace WideWorldCalendar.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    public class ScheduledNotificationBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var data = Data.GetInstance();

            var teamsWithReminders = data.GetMyCurrentTeams().Where(t => t.SendGameTimeReminders).ToList();
            var todaysTeamGamesWithReminders =
                teamsWithReminders.SelectMany(
                    t => data.GetGames(t.Id).Where(g => g.ScheduledDateTime.Date == DateTime.Now.Date))
                    .GroupBy(g => g.MyTeamId);

            foreach (var teamGames in todaysTeamGamesWithReminders)
            {
                string notificationTitle;

                switch (teamGames.Count())
                {
                    case 1:
                        notificationTitle = "Game Tonight!";
                        break;
                    case 2:
                        notificationTitle = "Double Header Tonight!";
                        break;
                    case 3:
                        notificationTitle = "Triple Header Tonight!";
                        break;
                    default:
                        notificationTitle = "Games Tonight!";
                        break;
                }
                var currentTeam = teamsWithReminders.First(t => t.Id == teamGames.Key);
                var notificationMessage =
                    $"{currentTeam.TeamName} @ {string.Join(",", teamGames.Select(g => g.ScheduledDateTime.ToString("t")))}";

                CreateNotification(context, currentTeam.Id, notificationTitle, notificationMessage);
            }

        }

        private static void CreateNotification(Context context, int teamId, string title, string message)
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
            notificationManager?.Notify(teamId, notification);
        }
    }
}