using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Mobile;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace WideWorldCalendar.Droid
{
	[Activity(Label = "Wide World Calendar", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { "android.intent.action.VIEW" },
        Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
                  DataScheme = WideWorldCalendar.Constants.ScheduleDeepLinkScheme,
                  DataHost = WideWorldCalendar.Constants.ScheduleDeepLinkDataHost)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
            AndroidAppLinks.Init(this);

            MobileCenter.Configure("31e541dc-2476-4e59-8da0-519cea09b4ad");
            LoadApplication(new App());
		}
	}
}
