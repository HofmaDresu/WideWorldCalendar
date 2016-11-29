namespace WideWorldCalendar.Droid.Utilities
{
    public interface IUnifiedAnalytics
    {
        void SetOnDefaultTracker(string key, string value);
        void CreateAndSendEventOnDefaultTracker(string category, string action, string label, long? value);
        void SendScreenHitOnDefaultTracker(string screenName);
    }
}