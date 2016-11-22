using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace WideWorldCalendar.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());


            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound, (approved, err) =>
            {
            });
            
            var intentIDs = new string[] { };

            var category = UNNotificationCategory.FromIdentifier(Constants.GameTonightNotification, new UNNotificationAction[] {}, intentIDs, UNNotificationCategoryOptions.CustomDismissAction);

            var categories = new[] { category };
            UNUserNotificationCenter.Current.SetNotificationCategories(new NSSet<UNNotificationCategory>(categories));

            return base.FinishedLaunching(app, options);
		}
	}
}
