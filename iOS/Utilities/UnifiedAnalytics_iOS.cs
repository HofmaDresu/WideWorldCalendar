using Foundation;
using Google.Analytics;
using WideWorldCalendar.iOS.Utilities;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(UnifiedAnalytics_iOS))]
namespace WideWorldCalendar.iOS.Utilities
{
    public class UnifiedAnalytics_iOS : IUnifiedAnalytics
    {
        public UnifiedAnalytics_iOS()
        {
			IosAnalytics.Instance();
        }

        private static ITracker DefaultTracker
        {
            get
            {
#if DEBUG
                Gai.SharedInstance.DryRun = true;
#endif

                Gai.SharedInstance.DefaultTracker.SetAllowIdfaCollection(true);

                return Gai.SharedInstance.DefaultTracker;
            }
        }

        public void SendScreenHitOnDefaultTracker(string screenName)
        {
            Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, screenName);

            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
        }

        public void SetOnDefaultTracker(string key, string value)
        {
            DefaultTracker.Set(key, value);
        }
        private static void SendOnDefaultTracker(NSDictionary eventToSend)
        {
            DefaultTracker.Send(eventToSend);
        }

        public void CreateAndSendEventOnDefaultTracker(string category, string action, string label, long? value)
        {
            SendOnDefaultTracker(CreateEvent(category, action, label, value));
        }

        private static NSDictionary CreateEvent(string category, string action, string label, long? value)
        {
            return DictionaryBuilder.CreateEvent(category, action, label, value).Build();
        }
    }

	class IosAnalytics
	{
		private static IosAnalytics _instance;

		private IosAnalytics()
		{

            Gai.SharedInstance.GetTracker(ThirdPartyIds.AnalyticsTrackingId);
		}

		public static IosAnalytics Instance()
		{
			return _instance ?? (_instance = new IosAnalytics());
		}
	}
}
