using System.Net;

namespace WideWorldCalendar.ScheduleFetcher
{
    public interface IProxyService
    {
        IWebProxy Proxy { get; }
    }
}
