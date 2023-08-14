namespace WebScrapper.Core.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }

        public int SearchEngineId { get; set; }

        public string SearchUrl { get; set; }

        public string SearchEngineTitle { get; set; }
        public int NumberOfResultsToSearchIn { get; set; }
    }
}
