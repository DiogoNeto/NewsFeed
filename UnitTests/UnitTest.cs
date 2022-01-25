using System.Threading.Tasks;
using Xunit;
using NewsFeed.Controllers;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public async Task TestTypeGetAsync()
        {
            var newsController = new NewsController();
            Assert.Equal(newsController.GetType().Name, "NewsController");
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var newsController = new NewsController();
            Assert.NotNull(newsController.Get("https://feeds.services.tv2.dk/api/feeds/nyheder/rss"));
        }
    }
}