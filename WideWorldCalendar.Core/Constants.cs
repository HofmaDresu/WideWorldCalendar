namespace WideWorldCalendar
{
    public static class Constants
    {
        public const string AnalyticsCategoryUserAction = "User Action";
        public const string AnalyticsCategoryNotification = "Notification";
        public const string AnalyticsLabelViewTeamSchedule = "View Team Schedule";
        public const string AnalyticsLabelGame = "Game";
        public const string Tie = "Tie";
        public const string Win = "Win";
        public const string Loss = "Loss";

        public const string ScheduleDeepLinkScheme = "wwc";
        public const string ScheduleDeepLinkDataHost = "WideWorldCalendar";
        public static readonly string ScheduleDeepLinkUrl = ScheduleDeepLinkScheme + "://" + ScheduleDeepLinkDataHost + "/TeamSchedule?id=";
    }
}
