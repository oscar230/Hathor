using Flurl.Http.Configuration;
using Hathor.Api.Services;
using Hathor.Api.Services.TrackRepositoryServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace Hathor.Api.Test
{
    [TestClass]
    public class SliderTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private IFlurlClientFactory _flurlClientFactory;
        private UserAgentService _userAgentService;
        private SliderTrackRepositoryService _sliderTrackRepositoryService;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [TestInitialize]
        public void Initialize()
        {
            _flurlClientFactory = new PerBaseUrlFlurlClientFactory();
            _userAgentService = new UserAgentService(new DebugLogger<UserAgentService>());
            _sliderTrackRepositoryService = new SliderTrackRepositoryService(new DebugLogger<SliderTrackRepositoryService>(), _flurlClientFactory, _userAgentService);
        }

        private void QueryTest(string artist)
        {
            IEnumerable<Track> tracks = _sliderTrackRepositoryService.Query(artist).GetAwaiter().GetResult();
            Assert.IsNotNull(tracks);
            Assert.IsTrue(tracks.Any());
            Assert.IsInstanceOfType(tracks.FirstOrDefault(), typeof(Track));
            Assert.IsInstanceOfType(tracks.LastOrDefault(), typeof(Track));
            Assert.IsNotNull(tracks.FirstOrDefault()?.Artists?.FirstOrDefault());
        }

        [TestMethod]
        public void QueryAvicii()
        {
            const string artist = "Avicii";
            QueryTest(artist);
        }

        [TestMethod]
        public void QueryMartinGarrix()
        {
            const string artist = "Martin Garrix";
            QueryTest(artist);
        }
    }
}