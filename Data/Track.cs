using System;
using System.Web;

namespace hathor.Data
{
    public class Track
    {
        private const string sliderBaseUri = "https://slider.kz/";
        private string sliderId;
        private long sliderDuration;
        private string sliderTitArt;
        private string sliderUrl;
        private string sliderExtra;

        public Track(
            string sliderId,
            long sliderDuration,
            string sliderTitArt,
            string sliderUrl,
            string sliderExtra
        )
        {
            this.sliderId = sliderId;
            this.sliderDuration = sliderDuration;
            this.sliderTitArt = sliderTitArt;
            this.sliderUrl = sliderUrl;
            this.sliderExtra = sliderExtra;
        }

        public string FullTitle => this.sliderTitArt;
        public long DurationInSeconds => this.sliderDuration;

        public Uri DownloadUri =>
            new Uri(
                string.Format(
                    "{0}{1}/{2}/{3}.mp3?extra={4}",
                    sliderBaseUri,
                    this.sliderId,
                    this.sliderDuration,
                    this.sliderUrl,
                    HttpUtility.UrlEncodeUnicode(this.sliderTitArt),
                    this.sliderExtra
                )
            ); 
    }
}