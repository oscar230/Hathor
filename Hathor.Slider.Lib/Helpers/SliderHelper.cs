using Hathor.Common.Models;
using Hathor.Slider.Lib.Models.Slider;
using System.Web;

namespace Hathor.Slider.Lib.Helpers
{
    public static class SliderHelper
    {
        private static readonly string DEFAULT_ARTIST = string.Empty;
        private const string ARTIST_TRACK_SEPARATOR = " - ";
        private const char ARTISTS_SEPARATOR = ',';

        public static string DownloadPathAndQuery(Models.Slider.Track sliderTrack)
        {
            var extraQuery = sliderTrack.ExtraInformation is not null ? HttpUtility.UrlEncode(sliderTrack.ExtraInformation.ToString()) : "null";
            return $"download/{sliderTrack.Id}/{sliderTrack.Duration}/{sliderTrack.Url}/{HttpUtility.UrlEncode(sliderTrack.TitArt)}.mp3?extra={extraQuery}";
        }

        public static string GetTitle(Models.Slider.Track sliderTrack)
        {
            if (sliderTrack.TitArt is not null)
            {
                return sliderTrack.TitArt.Split(ARTIST_TRACK_SEPARATOR).LastOrDefault() ?? DEFAULT_ARTIST;
            }
            throw new Exception("No titArt set, cannot get title.");
        }

        public static IEnumerable<Artist> GetArtistsFromSliderTrack(Models.Slider.Track sliderTrack)
        {
            if (sliderTrack.TitArt is not null)
            {
                return ParseArtistsFromFullTitle(sliderTrack.TitArt);
            }
            throw new Exception("No titArt set, cannot get artists.");
        }

        private static IEnumerable<Artist> ParseArtistsFromFullTitle(string titArt)
        {
            if (titArt.Contains(ARTIST_TRACK_SEPARATOR))
            {
                var splitted = titArt.Split(ARTIST_TRACK_SEPARATOR);
                if (splitted?.Length == 2)
                {
                    if (splitted[1].Contains(ARTISTS_SEPARATOR))
                    {
                        var artists = splitted[1].Split(ARTISTS_SEPARATOR);
                        if (artists?.Length > 0)
                        {
                            return artists.Select(a => new Artist(a));
                        }
                    }
                    else
                    {
                        return new Artist[1]
                        {
                            new Artist(splitted[1])
                        };
                    }
                }
            }
            throw new ArgumentException($"Could not parse artists from {titArt}.");
        }

        public static Common.Models.Track GetTrackFromSliderQueriedTrack(Models.Slider.Track queriedTrack)
        {
            return new Common.Models.Track()
            {
                Id = new Guid(),
                Title = SliderHelper.GetTitle(queriedTrack),
                Artists = SliderHelper.GetArtistsFromSliderTrack(queriedTrack)
            };
        }

        public static List<Common.Models.Track> GetTracksFromSliderQueryResult(TrackList queryResult)
        {
            if (queryResult?.SearchResponse?.SliderTracks is not null && queryResult.SearchResponse.SliderTracks.Any())
            {
                return queryResult.SearchResponse.SliderTracks.Select(sliderTrack => GetTrackFromSliderQueriedTrack(sliderTrack)).ToList();
            }
            else
            {
                return new List<Common.Models.Track>();
            }
        }
    }
}
