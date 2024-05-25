using System.Linq;
using Xunit;
using LogConverter.Core.Models;
using LogConverter.Core.Services;

namespace LogConverter.Tests
{
    public class LogParserTests
    {
        [Fact]
        public void ParseLogs_ValidContent_ReturnsCorrectEntries()
        {
            var parser = new LogParserService();
            var content = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\n";
            var entries = parser.ParseLogs(content).ToList();

            Assert.Single(entries);
            Assert.Equal(200, entries[0].StatusCode);
            Assert.Equal("HIT", entries[0].CacheStatus);
            Assert.Equal("GET", entries[0].HttpMethod);
            Assert.Equal("/robots.txt", entries[0].UriPath);
            Assert.Equal(100, (int)Math.Round(entries[0].ResponseTime));
        }
    }
}
