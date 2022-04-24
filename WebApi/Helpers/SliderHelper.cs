using Hathor.Api.Models;
using Hathor.Api.Models.Slider;
using System.Web;
using WebApi.Models;

namespace Hathor.Api.Helpers
{
    public static class SliderHelper
    {
        private static readonly string DEFAULT_ARTIST = string.Empty;
        private const string ARTIST_TRACK_SEPARATOR = " - ";
        private const char ARTISTS_SEPARATOR = ',';
        private const string DOWNLOAD_BASE_URI = "https://slider.kz/download";

        public static Uri GetDownloadUriFromSliderTrack(QueriedTrack sliderTrack)
        {
            var extraQuery = sliderTrack.ExtraInformation is not null ? HttpUtility.UrlEncode(sliderTrack.ExtraInformation.ToString()) : "null";
            var strUri = $"{DOWNLOAD_BASE_URI}/{sliderTrack.Id}/{sliderTrack.Duration}/{sliderTrack.Url}/{HttpUtility.UrlEncode(sliderTrack.TitArt)}.mp3?extra={extraQuery}";
            return new Uri(strUri);
        }

        public static string GetTitle(QueriedTrack sliderTrack)
        {
            if (sliderTrack.TitArt is not null)
            {
                return sliderTrack.TitArt.Split(ARTIST_TRACK_SEPARATOR).LastOrDefault() ?? DEFAULT_ARTIST;
            }
            throw new Exception("No titArt set, cannot get title.");
        }

        public static IEnumerable<Artist> GetArtistsFromSliderTrack(QueriedTrack sliderTrack)
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

        public static Track GetTrackFromSliderQueriedTrack(QueriedTrack queriedTrack)
        {
            return new Track()
            {
                Id = new Guid(),
                Title = SliderHelper.GetTitle(queriedTrack),
                Artists = SliderHelper.GetArtistsFromSliderTrack(queriedTrack),
                RepositoryInternalId = queriedTrack.Id,
                Repository = RepositoryHelper.GetSliderRepository
            };
        }

        public static IEnumerable<Track> GetTracksFromSliderQueryResult(QueryResult queryResult)
        {
            if (queryResult?.TrackList?.SliderTracks is not null && queryResult.TrackList.SliderTracks.Any())
            {
                return queryResult.TrackList.SliderTracks.Select(sliderTrack => GetTrackFromSliderQueriedTrack(sliderTrack));
            }
            else
            {
                return Enumerable.Empty<Track>();
            }
        }
    }
}
