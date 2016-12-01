using WideWorldCalendar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WideWorldCalendar
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));

            //MainPage = new NavigationPage(new CurrentTeamsPage());
            MainPage = new MenuPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
