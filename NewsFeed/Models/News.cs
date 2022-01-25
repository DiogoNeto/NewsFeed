using System.ComponentModel.DataAnnotations;

namespace NewsFeed.Models
{
    public class News
    {
        [Key]
        public int id { get; set; }

        public string title { get; set; }

        public string link { get; set; }

        public string description { get; set; }

        public string pubDate { get; set; }

        public Image img { get; set; }

        public Entry[] entries { get; set; }

    }
}
