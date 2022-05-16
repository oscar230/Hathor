using Flurl.Http;
using Flurl.Http.Testing;
using Hathor.Slider.Lib;
using Hathor.Slider.Lib.Models.Slider;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Hathor.Slider.Test
{
    [TestClass]
    public class QueryTest
    {
        private Logger<Query>? _logger;
        private HttpTest? _httpTest;
        private IFlurlClient? _flurlClient;
        private Query? _query;

        [TestInitialize]
        public void Setup()
        {
            _logger = Mock.Of<Logger<Query>>();
            _httpTest = new HttpTest();
            _flurlClient = new FlurlClient();
            _query = new Query(_logger, _flurlClient);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (_query is not null)
            {
                _query.Dispose();
            }
            if (_flurlClient is not null)
            {
                _flurlClient.Dispose();
            }
            if (_httpTest is not null)
            {
                _httpTest.Dispose();
            }
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("Levels")]
        public async void Search(string? query)
        {
            List<Track> tracks = await Query.Search(query);
            Assert.IsNotNull(tracks);
            Assert.IsTrue(tracks.Any());
        }
    }
}
