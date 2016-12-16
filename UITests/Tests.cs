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
	    public void TeamIsDisplayedWhenAdded()
	    {
	        AddTeamAndVerify(0);
	    }


	    [Test]
		public void WelcomeTextIsDisplayed()
		{
		    AddTeamAndVerify(0);
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

	    private void AddTeamAndVerify(int teamIndex)
	    {
	        app.WaitForElement("AddTeamButton");
	        app.Tap("AddTeamButton");
	        app.WaitForElement("ActivityIndicator");
	        app.WaitForNoElement("ActivityIndicator");
	        app.Tap("SeasonPicker");
	        app.Tap("text1");
	        app.WaitForElement("LeaguePicker");
	        app.Tap("LeaguePicker");
	        app.Tap("text1");
	        app.WaitForElement("DivisionPicker");
	        app.Tap("DivisionPicker");
	        app.Tap("text1");
	        app.WaitForElement("TeamPicker");
	        app.Tap("TeamPicker");
	        app.Tap(c => c.Marked("text1").Index(teamIndex));
	        app.WaitForElement("GetScheduleButton");
	        app.Tap("GetScheduleButton");
	        app.WaitForElement("SaveScheduleCommand");
	        app.Tap("SaveScheduleCommand");
	        app.Tap("button1");
	        app.WaitForElement("AddTeamButton");
	        Assert.AreEqual(teamIndex + 1, app.Query(c => c.Class("ViewCellRenderer_ViewCellContainer")).Length);
	    }
	}
}
