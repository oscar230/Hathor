using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace hathor.Data
{
    public class SliderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public SliderService(IHttpClientFactory clientFactory       )
        {
            _clientFactory = clientFactory;
        }

        public List<Track> SearchTracks(string searchQuery)
        {
            Uri uri = new Uri(string.Format(
                "https://slider.kz/vk_auth.php?q={0}",
                HttpUtility.UrlEncodeUnicode(searchQuery)
            ));
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "text/html");
            request.Headers.Add("User-Agent", "Mozilla/5.0");
            var client = _clientFactory.CreateClient();
            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                using (Stream stream = response.Content.ReadAsStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        return JsonSerializer
                            .Deserialize<ResponseSliderSearch>(json)
                            .responseSliderSearchAudios
                            .responseSliderSearchTracks.Select(
                                t => new Track(
                                    sliderId: t.Id,
                                    sliderDuration: t.Duration,
                                    sliderExtra: t.Extra,
                                    sliderTitArt: t.TitArt,
                                    sliderUrl: t.Url
                                )
                            ).ToList<Track>();
                    }
                }
            }
            else
            {
                return new List<Track>();
            }
        }
    }
}
