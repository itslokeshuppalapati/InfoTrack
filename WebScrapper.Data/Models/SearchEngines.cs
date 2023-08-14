namespace WebScrapper.Data.Models
{
    public class SearchEngines : BaseModel
    {
        public string Title { get; set; }

        public string BaseUrl { get; set; }
        
        public string SearchUrl { get; set; }

        public string ResultExtractionExpression { get; set; }

    }
}
