using WebApi.Models.Slider;

namespace WebApi.Services
{
    public interface IDbService : IDisposable
    {
        bool AddSliderTrack(SliderTrack sliderTrack);

        bool AddSliderTracks(IEnumerable<SliderTrack> sliderTracks);
    }
}
