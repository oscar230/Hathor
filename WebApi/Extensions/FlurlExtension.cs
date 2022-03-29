using Flurl.Http;
using System.Text.Json;
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

#pragma warning disable CA1068 // CancellationToken parameters must come last
#pragma warning disable IDE0034 // Simplify 'default' expression
        public static async Task<T> Deserialize<T>(this IFlurlRequest request, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, ILogger? logger = null, JsonSerializerOptions? jsonSerializerOptions = null)
#pragma warning restore IDE0034 // Simplify 'default' expression
#pragma warning restore CA1068 // CancellationToken parameters must come last
        {
            string rawJson = await request.GetStringAsync(cancellationToken, completionOption);
            if (logger is not null)
            {
                logger.LogDebug($"RAW JSON: {rawJson}");
            }
            if (rawJson is not null && rawJson.Length > 0)
            {
                T? deserializedObject = JsonSerializer.Deserialize<T>(rawJson, jsonSerializerOptions);
                if (deserializedObject is not null)
                {
                    return deserializedObject;
                }
                throw new JsonException($"Could not deserialize type {typeof(T)} from Json: {rawJson}");
            }
            throw new JsonException("Json is either null or of zero length.");
        }
    }
}
