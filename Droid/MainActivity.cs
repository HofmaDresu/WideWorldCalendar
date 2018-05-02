using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace WideWorldCalendar.Droid
{
	[Activity(Label = "Wide World Calendar", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { "android.intent.action.VIEW" },
        Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
                  DataScheme = WideWorldCalendar.Constants.ScheduleDeepLinkScheme,
                  DataHost = WideWorldCalendar.Constants.ScheduleDeepLinkDataHost)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
            CreateNotificationChannels();

            TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            AndroidAppLinks.Init(this);

            LoadApplication(new App());
		}

        private void CreateNotificationChannels()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);

                var gameChannel = new NotificationChannel(Constants.GameNotificationChannelId, "Game Time Notifications", NotificationImportance.Low)
                {
                    Description = "These notifications remind you of an upcoming game."
                };
                gameChannel.EnableVibration(true);

                var generalChannel = new NotificationChannel(Constants.GeneralNotificationChannelId, "General Notifications", NotificationImportance.Low)
                {
                    Description = "These notifications remind you of schedule changes and new schedule availability."
                };
                generalChannel.EnableVibration(true);

                notificationManager.CreateNotificationChannel(gameChannel);
                notificationManager.CreateNotificationChannel(generalChannel);
            }
        }
	}
}
