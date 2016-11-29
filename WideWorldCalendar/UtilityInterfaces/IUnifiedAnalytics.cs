namespace WideWorldCalendar.UtilityInterfaces
{
    public interface IUnifiedAnalytics
    {
        void SetOnDefaultTracker(string key, string value);
        void CreateAndSendEventOnDefaultTracker(string category, string action, string label = null, long? value = null);
        void SendScreenHitOnDefaultTracker(string screenName);
    }
}