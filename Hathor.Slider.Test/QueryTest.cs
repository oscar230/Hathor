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
        private readonly Mock<Logger<Query>> _mockLogger;

        public QueryTest()
        {
            _mockLogger = new Mock<Logger<Query>>();
        }

        [TestMethod]
        public async void Search()
        {
            const string QUERY = "Avicii Levels";
            List<Track> tracks = await Query.Search(_mockLogger.Object, QUERY);
            Assert.IsNotNull(tracks);
            Assert.IsTrue(tracks.Any());
        }
    }
}
