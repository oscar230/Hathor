using Flurl.Http;
using Flurl.Http.Testing;
using Hathor.Slider.Lib;
using Hathor.Slider.Lib.Models.Slider;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hathor.Slider.Test
{
    [TestClass]
    public class QueryTest
    {
        private Logger<Query> _logger;
        private HttpTest _httpTest;
        private IFlurlClient _flurlClient;
        private Query _query;

        public QueryTest(Logger<Query> logger, HttpTest httpTest, IFlurlClient flurlClient, Query query)
        {
            _logger = logger;
            _httpTest = httpTest;
            _flurlClient = flurlClient;
            _query = query;
        }

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
            _query.Dispose();
            _flurlClient.Dispose();
            _httpTest.Dispose();
        }

        [TestMethod]
        [DataRow("abcdefg")]
        [DataRow("Future")]
        [DataRow("Harry Styles As It Was")]
        [DataRow("Imagine Dragons X JID")]
        [DataRow("Levels")]
        [DataRow(null, "null")]
        [DataRow("skrillex")]
        [DataRow("Tu Pîroz Î Û Em Navê Te Bilind Dikin")]
        [DataRow("VØST Ü")]
        [DataRow("Лирика")]
        public async void Search(string query, string? explicitSearchResponsePath = null)
        {
            string searchResponsePath = $"TestResources\\SearchResponses\\{explicitSearchResponsePath ?? query}.json";
            string correctResponseAsJson = File.ReadAllText(searchResponsePath);
            _httpTest.ForCallsTo($"{_flurlClient.BaseUrl}*").WithVerb("GET").RespondWith(correctResponseAsJson, 200);
            List<Track> tracks = await _query.Search(query);
            Assert.IsNotNull(tracks);
            Assert.IsTrue(tracks.Any());
        }
    }
}
