using WebApi.Helpers;
using WebApi.Models.Slider;

namespace WebApi.Models.Common
{
    public class Track
    {
        Guid Id { get; }

        string Title { get; }

        IEnumerable<Artist> Artists { get; }

        string? InternalId { get; }

        Repository Repository { get; }

        public Track(SliderTrack sliderTrack)
        {
            Id = new Guid();
            Title = SliderHelper.GetTitle(sliderTrack);
            Artists = SliderHelper.GetArtistsFromSliderTrack(sliderTrack);
            InternalId = sliderTrack.Id;
            Repository = RepositoryHelper.GetSliderRepository;
        }
    }
}
