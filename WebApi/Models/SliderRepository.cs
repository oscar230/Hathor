namespace WebApi.Models
{
    public class SliderRepository : IRepository
    {
        public Guid Guid => new("00000000-0000-0000-0000-95de5c960db7");

        public string DisplayName => "Slider";

        public Uri HomePageUri => new("https://slider.kz/");
    }
}
