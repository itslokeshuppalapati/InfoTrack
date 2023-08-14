namespace WebScrapper.Data.Models
{
    public class SearchResults : BaseModel
    {
        public string Url { get; set; }

        public string KeyWords { get; set; }

        public string Ranking { get; set; }

        public DateTime SearchDate { get; set; }

    }
}
