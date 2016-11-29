using Foundation;
using Google.Analytics;
using WideWorldCalendar.UtilityInterfaces;

namespace WideWorldCalendar.iOS.Utilities
{
    public class UnifiedAnalytics_iOS : IUnifiedAnalytics
    {
        private UnifiedAnalytics_iOS()
        {
            Gai.SharedInstance.GetTracker(ThirdPartyIds.AnalyticsTrackingId);
        }

        private static UnifiedAnalytics_iOS _unifiedAnalytics;
        public static UnifiedAnalytics_iOS GetInstance()
        {
            return _unifiedAnalytics ?? (_unifiedAnalytics = new UnifiedAnalytics_iOS());
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
}
