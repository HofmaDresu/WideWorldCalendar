using System.Net;
using CoreFoundation;
using WideWorldCalendar.ScheduleFetcher;

namespace WideWorldCalendar.iOS.ScheduleFetcher
{
    class ProxyService : IProxyService
    {
        public IWebProxy Proxy => CFNetwork.GetDefaultProxy() ?? WebRequest.GetSystemWebProxy();
    }
}