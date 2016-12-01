 using System;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
 using Microsoft.Azure.Mobile;
 using UIKit;
using UserNotifications;
using WideWorldCalendar.iOS.Utilities;
using WideWorldCalendar.Persistence;
using WideWorldCalendar.ScheduleFetcher;
using Xamarin.Forms.Platform.iOS;

namespace WideWorldCalendar.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			SetUpTheme();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif
            MobileCenter.Configure("ce6abde5-5977-4858-bf93-d7661ab4fbf9");
            LoadApplication(new App());


            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound, (approved, err) =>
            {
            });
            
            var intentIDs = new string[] { };

            var category = UNNotificationCategory.FromIdentifier(Constants.GameTonightNotification, new UNNotificationAction[] {}, intentIDs, UNNotificationCategoryOptions.CustomDismissAction);

            var categories = new[] { category };
            UNUserNotificationCenter.Current.SetNotificationCategories(new NSSet<UNNotificationCategory>(categories));

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(24*60*60);


            return base.FinishedLaunching(app, options);
        }

		private void SetUpTheme()
		{
			UISwitch.Appearance.OnTintColor = Colors.SecondaryColor.ToUIColor();
			UINavigationBar.Appearance.BarTintColor = Colors.PrimaryColor.ToUIColor();
		}

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 1;
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

            var alert = new UIAlertView { Title = notification.AlertTitle, Message = notification.AlertBody };
            alert.AddButton("OK");
            alert.Show();
        }

	    public override async void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
	    {
	        var dataUpdated = false;

            var dataInstance = Data.GetInstance(new SQLite_iOS().GetConnection());
	        var localNotifications = new LocalNotification_iOS();

	        try
	        {
	            if (dataInstance.ShowScheduleChangedNotifications())
	            {
	                localNotifications.ClearAllNotifications();
	                dataUpdated = await UpdateSchedulesIfNeeded(dataInstance, localNotifications);
	            }

	            if (dataInstance.ShowNewSeasonAvailableNotifications())
	            {
	                dataUpdated = await CheckForNewSeason(dataInstance, localNotifications);
	            }
	        }
	        catch (Exception)
	        {
	            completionHandler(UIBackgroundFetchResult.Failed);
	        }
	        finally
            {
                localNotifications.ScheduleGameNotifications();
            }

	        completionHandler(dataUpdated ? UIBackgroundFetchResult.NewData : UIBackgroundFetchResult.NoData);
	    }

        private static async Task<bool> CheckForNewSeason(Data dataInstance, LocalNotification_iOS localNotifications)
        {
            var scheduleFetcher = new RestScheduleFetcher();
            var scheduleHtml = await scheduleFetcher.GetSchedulesPage();
            var seasons = scheduleFetcher.GetSeasons(scheduleHtml);

            if (seasons.Any(dataInstance.IsNewSeason))
            {
                dataInstance.UpdateSeasons(seasons);
				localNotifications.CreateNotification(DateTime.Now.AddMinutes(1), "Wide World Sports",
                   "A new season is available.", Constants.NewSeasonRequestId, Constants.NewSeasonNotification);
                return true;
            }
            return false;
        }

        private static async Task<bool> UpdateSchedulesIfNeeded(Data dataInstance, LocalNotification_iOS localNotifications)
        {
            var scheduleFetcher = new RestScheduleFetcher();
            var newData = false;
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
					localNotifications.CreateNotification(DateTime.Now.AddMinutes(1), "Team Schedule Changed",
                        $"The schedule for {team.TeamName} has been updated.", team.Id, Constants.ScheduleChangedNotification);
                    newData = true;
                }
            }
            return newData;
        }
    }
}
