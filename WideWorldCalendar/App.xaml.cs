﻿using WideWorldCalendar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using WideWorldCalendar.ScheduleFetcher;
using System;
using WideWorldCalendar.Persistence;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WideWorldCalendar
{
	public partial class App : Application
	{
        private static App _instance;
        public static App GetInstance()
        {
            return _instance;
        }

		public App()
		{
			InitializeComponent();
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));

#if UITEST
            DependencyService.Register<MockScheduleFetcher>();
#else
            DependencyService.Register<RestScheduleFetcher>();
#endif

            
            MainPage = new MenuPage();
            _instance = this;
		}

		protected override void OnStart()
        {
            foreach (var team in Data.GetInstance().GetMyCurrentTeams())
            {


                var pageLink = new AppLinkEntry
                {
                    Title = team.TeamName,
                    Description = team.NameAndColor,
                    AppLinkUri = new Uri(Constants.ScheduleDeepLinkUrl + team.Id, UriKind.RelativeOrAbsolute),
                    IsLinkActive = true,
                    //Thumbnail = ImageSource.FromFile("monkey.png")
                };

                Application.Current.AppLinks.RegisterLink(pageLink);
            }
        }

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            string appDomain = $"{Constants.ScheduleDeepLinkScheme}://{Constants.ScheduleDeepLinkDataHost}/";
            if (!uri.ToString().ToLowerInvariant().StartsWith(appDomain.ToLowerInvariant()))
            {
                return;
            }

            var teamId = int.Parse(uri.ToString().Split('=')[1]);

            MainPage = new MenuPage();
            await (MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new TeamSchedulePage(teamId));

            base.OnAppLinkRequestReceived(uri);
        }

        public void OnAppLinkRequestReceived_WorkAround(Uri uri)
        {
            OnAppLinkRequestReceived(uri);
        }
    }
}
