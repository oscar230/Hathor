using System.Net;
using System.Web;

namespace WebApi
{
    public class SliderFacade
    {
        private readonly ILogger _logger;
        const string BaseURI = "https://slider.kz";

        public SliderFacade(ILogger logger)
        {
            _logger = logger;
        }

        private HttpResponseMessage httpGet(HttpRequestMessage httpRequestMessage)
        {
            try
            {
                httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)");
                using (var httpClient = new HttpClient())
                {
                    _logger.LogInformation("Requesting {0}", httpRequestMessage.RequestUri);
                    return httpClient.Send(httpRequestMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        public string Search(string searchQuery)
        {
            var uri = new Uri(BaseURI + "/vk_auth.php?q=" + HttpUtility.UrlEncode(searchQuery));
            var res = httpGet(new HttpRequestMessage(HttpMethod.Get, uri));
            if (res.IsSuccessStatusCode)
                return res.Content.ReadAsStringAsync().Result;
            else
                return "Error!";
        }
    }
}
