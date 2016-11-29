using System;
using System.Collections.Generic;
using Android.Content;
using Android.Gms.Analytics;
using WideWorldCalendar.Droid.Utilities;
using WideWorldCalendar.UtilityInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(UnifiedAnalytics_Android))]
namespace WideWorldCalendar.Droid.Utilities
{
    public class UnifiedAnalytics_Android : IUnifiedAnalytics
    {
        /// <summary>
        /// Only use for Xamarin DI
        /// </summary>
        public UnifiedAnalytics_Android() : this(Forms.Context) { }

        public UnifiedAnalytics_Android(Context context)
        {
            AndroidAnalytics.Instance(context);
        }

        private Tracker DefaultTracker => AndroidAnalytics.Instance().Tracker;

        public void SetOnDefaultTracker(string key, string value)
        {
            DefaultTracker.Set(key, value);
        }

        private void SendOnDefaultTracker(IDictionary<string, string> eventToSend)
        {
            DefaultTracker.Send(eventToSend);
        }

        public void SendScreenHitOnDefaultTracker(string screenName)
        {
            DefaultTracker.SetScreenName(screenName);
            DefaultTracker.Send(new HitBuilders.ScreenViewBuilder().Build());

            DefaultTracker.SetScreenName(null);
        }

        public void CreateAndSendEventOnDefaultTracker(string category, string action, string label, long? value = null)
        {
            SendOnDefaultTracker(CreateEvent(category, action, label, value));
        }

        private IDictionary<string, string> CreateEvent(string category, string action, string label, long? value)
        {
            var eventBuilder = new HitBuilders.EventBuilder()
                .SetCategory(category)
                .SetAction(action)
                .SetLabel(label);
            if (value.HasValue)
            {
                eventBuilder = eventBuilder.SetValue(value.Value);
            }
            return eventBuilder.Build();
        }

    }

    class AndroidAnalytics
    {
        private static AndroidAnalytics _instance;
        private readonly Tracker _tracker;

        private AndroidAnalytics(Context context)
        {
            if (_tracker == null)
            {
                var analytics = GoogleAnalytics.GetInstance(context);
                Analytics = analytics;
                _tracker = analytics.NewTracker(Resource.Xml.GlobalTracker);
                _tracker.EnableAutoActivityTracking(false);
                _tracker.EnableExceptionReporting(true);
                _tracker.EnableAdvertisingIdCollection(true);

#if DEBUG
                //analytics.SetDryRun(true);
#endif
            }
        }

        public static AndroidAnalytics Instance(Context context)
        {
            return _instance ?? (_instance = new AndroidAnalytics(context));
        }

        public static AndroidAnalytics Instance()
        {
            if (_instance == null)
            {
                throw new InvalidOperationException("Context not set on instance");
            }
            return _instance;
        }

        public Tracker Tracker => _tracker;

        public GoogleAnalytics Analytics { get; }
    }
}