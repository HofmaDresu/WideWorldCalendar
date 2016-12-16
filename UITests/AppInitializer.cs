using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WideWorldCalendar.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
			    return ConfigureApp.Android
			        .ApkFile("../../../Droid/bin/UITest/com.hofmadresu.wide_world_calendar-Signed.apk")
			        .StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}
