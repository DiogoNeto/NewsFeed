using Microsoft.AspNetCore.Mvc;
using NewsFeed.Models;
using System.Xml.Linq;

namespace NewsFeed.Controllers
{
    [Route("news/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        [HttpGet("json"), FormatFilter]
        public IEnumerable<News> Get(string rss)
        {
            string RssFeedUrl = rss;

            List<News> news = new List<News>();
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);

                int itemId = 1;
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 desc = x.Element("description").Value,
                                 pubDate = x.Element("pubDate").Value,
                             }); 
                if(items != null)
                {
                    foreach(var i in items)
                    {
                        News n = new News
                        {
                            id = itemId,
                            title = i.title,
                            link = i.link,
                            description = i.desc,
                            pubDate = i.pubDate,
                        };
                        news.Add(n);
                        itemId++;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                throw ex;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                throw ex;
            }

            return news;
        }
    }
}
