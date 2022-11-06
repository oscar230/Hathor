using Hathor.Web.Mappers;
using Hathor.Web.Models;
using Hathor.Web.Models.Slider;
using System.Web;

namespace Hathor.Web.Helpers
{
    public static class SliderHelper
    {
        private const string ArtistTrackSeparator = " - ";
        private const char ARTISTS_SEPARATOR = ',';

        public static string DownloadPathAndQuery(Models.Slider.SliderTrack sliderTrack)
        {
            var extraQuery = sliderTrack.ExtraInformation is not null ? HttpUtility.UrlEncode(sliderTrack.ExtraInformation.ToString()) : "null";
            return $"download/{sliderTrack.Id}/{sliderTrack.Duration}/{sliderTrack.Url}/{HttpUtility.UrlEncode(sliderTrack.TitArt)}.mp3?extra={extraQuery}";
        }

        public static string GetTitle(SliderTrack sliderTrack)
        {
            if (sliderTrack.TitArt is not null)
            {
                string[] splitted = sliderTrack.TitArt.Split(ArtistTrackSeparator);
                if (splitted.Length == 2)
                {
                    return splitted[1];
                }
                throw new ArgumentException($"{nameof(sliderTrack.TitArt)} is set, but cannot get title from its value: {sliderTrack.TitArt}");
            }
            throw new ArgumentNullException($"{nameof(sliderTrack.TitArt)} not set, cannot get title.");
        }

        public static IEnumerable<Artist> GetArtistsFromSliderTrack(Uri? sourceAsUrl, SliderTrack sliderTrack)
        {
            if (sliderTrack.TitArt is not null)
            {
                return ParseArtistsFromFullTitle(sliderTrack.TitArt, sourceAsUrl);
            }
            throw new ArgumentNullException("No titArt set, cannot get artists.");
        }

        private static IEnumerable<Artist> ParseArtistsFromFullTitle(string titArt, Uri? sourceAsUrl)
        {
            if (titArt.Contains(ArtistTrackSeparator))
            {
                var splitted = titArt.Split(ArtistTrackSeparator);
                if (splitted?.Length == 2)
                {
                    if (splitted[1].Contains(ARTISTS_SEPARATOR))
                    {
                        var artists = splitted[1].Split(ARTISTS_SEPARATOR);
                        if (artists?.Length > 0)
                        {
                            return artists.Select(artistName => new Artist(sourceAsUrl, artistName));
                        }
                    }
                    else
                    {
                        return new Artist[1]
                        {
                            new Artist(sourceAsUrl, splitted[1])
                        };
                    }
                }
            }
            throw new ArgumentException($"Could not parse artists from {titArt}.");
        }

        public static IEnumerable<Track> GetTracks(IEnumerable<SliderTrack> sliderTracks, Uri? sourceAsUrl)
        {
            return sliderTracks.Select(sliderTrack => SliderMapper.Map(sliderTrack, sourceAsUrl));
        }

        public static IEnumerable<Artist>? GetRemixers(SliderTrack track)
        {
            // TODO implement
            return null;
        }

        public static TimeSpan? GetDuration(SliderTrack track)
        {
            // TODO implement
            return null;
        }
    }
}
