using WideWorldCalendar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WideWorldCalendar.ScheduleFetcher;
using System;
using WideWorldCalendar.Persistence;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

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
            AppCenter.Start("android=c243444f-8660-4a55-b22f-8b47b9146e2a;" +
                  //"uwp={Your UWP App secret here};" +
                  "ios=5db09c9e-5cc5-48f0-a3a4-ede6ebeb31fd;" +
                  typeof(Analytics), typeof(Crashes), typeof(Distribute));

            foreach (var team in Data.GetInstance().GetMyCurrentTeams())
            {
                var pageLink = new AppLinkEntry
                {
                    Title = team.NameAndColor,
                    Description = team.Division,
                    AppLinkUri = new Uri(Constants.ScheduleDeepLinkUrl + team.Id, UriKind.RelativeOrAbsolute),
                    IsLinkActive = true
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
