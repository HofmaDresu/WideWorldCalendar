using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WideWorldCalendar.UITests
{
	[TestFixture(Platform.Android)]
	//[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed()
		{
            //Add teams
			app.WaitForElement("AddTeamButton");
		    app.Tap("AddTeamButton");
		    app.Repl();


            // Actual Test
		    //app.Tap("OK");
		    //app.WaitForElement(c => c.Text("Settings"));
            //app.Tap(c => c.Text("Settings"));
		    //app.WaitForElement(c => c.Class("PickerRenderer"));
		    //app.Tap(c => c.Class("PickerRenderer"));
		    //app.Tap(c => c.Text("12"));
            //app.Tap(c => c.Class("PickerRenderer"));
            //app.Tap(c => c.Text("9"));
		    //app.Back();
            //app.Repl();


		}
	}
}
