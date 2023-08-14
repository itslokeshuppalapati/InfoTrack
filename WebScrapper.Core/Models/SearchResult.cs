namespace WebScrapper.Core.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string KeyWords { get; set; }

        public string Ranking { get; set; }

        public string SearchDate { get; set; }
    }
}
