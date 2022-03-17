using HathorCommon.Models;
using WebApi.Helpers;
using WebApi.Models.Slider;

namespace WebApi.Models
{
    public class Track : ITrack
    {
        public Guid Id { get; }

        public string? Title { get; }

        public IEnumerable<Artist>? Artists { get; }

        public string? RepositoryInternalId { get; }

        public Repository? Repository { get; }

        public Track(SliderTrack sliderTrack)
        {
            Id = new Guid();
            Title = SliderHelper.GetTitle(sliderTrack);
            Artists = SliderHelper.GetArtistsFromSliderTrack(sliderTrack);
            RepositoryInternalId = sliderTrack.Id;
            Repository = RepositoryHelper.GetSliderRepository;
        }
    }
}
