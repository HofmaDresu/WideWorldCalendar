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
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using WideWorldCalendar.Utilities;
using System.Collections.Generic;

namespace WideWorldCalendar.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        private App _app;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			SetUpTheme();

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif
            MobileCenter.Configure("ce6abde5-5977-4858-bf93-d7661ab4fbf9");
            _app = new App();
            LoadApplication(_app);


            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound, (approved, err) =>
            {
                UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();
            });
            
            var intentIDs = new string[] { };

            var category = UNNotificationCategory.FromIdentifier(Constants.GameTonightNotification, new UNNotificationAction[] {}, intentIDs, UNNotificationCategoryOptions.CustomDismissAction);

            var categories = new[] { category };
            UNUserNotificationCenter.Current.SetNotificationCategories(new NSSet<UNNotificationCategory>(categories));

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(24*60*60);


            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            _app.OnAppLinkRequestReceived_WorkAround(url);
            return true;
        }
        
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            _app.OnAppLinkRequestReceived_WorkAround(url);
            return true;
        }

        public override void WillEnterForeground(UIApplication uiApplication)
        {
            base.WillEnterForeground(uiApplication);
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
	            dataUpdated = await UpdateSchedulesIfNeeded(dataInstance, localNotifications);

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
            var scheduleFetcher = DependencyService.Get<IScheduleFetcher>();
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
            var scheduleFetcher = DependencyService.Get<IScheduleFetcher>();
            var newData = false;


            if (dataInstance.ShowScheduleChangedNotifications())
            {
                localNotifications.ClearAllNotifications();
            }

            var teams = dataInstance.GetMyCurrentTeams();
            var dataFetchTasks = teams.Select(team => scheduleFetcher.GetTeamSchedule(team.Id)).ToList();
            try
            {
                await Task.WhenAll(dataFetchTasks);
            }
            catch (Exception)
            {
                //Eat Exception
                return false;
            }

            var serverGames = new List<Game>();
            foreach (var task in dataFetchTasks)
            {
                var teamGames = task.Result;
                var teamId = teamGames.FirstOrDefault()?.MyTeam?.Id;
                var teamName = teamGames.FirstOrDefault()?.MyTeam?.Name;
                if (!teamId.HasValue) continue;
                var currentGames = dataInstance.GetGames(teamId.Value);

                if (dataInstance.ShowScheduleChangedNotifications() && dataInstance.ScheduleHasChanged(currentGames, serverGames))
                {
                    localNotifications.CreateNotification(DateTime.Now.AddMinutes(1), "Team Schedule Changed",
                        $"The schedule for {teamName} has been updated.", teamId.Value, Constants.ScheduleChangedNotification);
                    newData = true;
                }
				serverGames.AddRange(teamGames);
            }
            dataInstance.UpdateSchedules(serverGames.Select(DataConverter.ConvertDtoToPersistence).ToList());
            return newData;
        }
    }
}
