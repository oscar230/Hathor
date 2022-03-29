using Flurl.Http;
using WebApi.Services;

namespace WebApi.Extensions
{
    public static class FlurlExtension
    {
        private static T WithRandomUserAgent<T>(this T clientOrRequest, UserAgentService userAgentService) where T : IHttpSettingsContainer
        {
            return clientOrRequest.WithHeader<T>("User-Agent", userAgentService.GetRandom());
        }

        public static T AtSlider<T>(this T clientOrRequest, UserAgentService userAgentService) where T : IHttpSettingsContainer
        {
            TimeSpan timeout = new(0, 3, 0);
            return WithRandomUserAgent(clientOrRequest, userAgentService).WithTimeout(timeout).WithHeader("Accept", "audio/mpeg").WithHeader("Accept-Encoding", "gzip, deflate, br").WithHeader("Accept-Language", "en-US").WithHeader("Connection", "keep-alive").WithHeader("Host", "slider.kz").WithHeader("Upgrade-Insecure-Requests", "1");
        }

        public static T AtLiveTracklist<T>(this T clientOrRequest, UserAgentService userAgentService) where T : IHttpSettingsContainer
        {
            TimeSpan timeout = new(0, 0, 10);
            return WithRandomUserAgent(clientOrRequest, userAgentService).WithTimeout(timeout);
        }
    }
}
