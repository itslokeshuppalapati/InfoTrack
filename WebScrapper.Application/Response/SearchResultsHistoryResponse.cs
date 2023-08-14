using WebScrapper.Core.Models;

namespace WebScrapper.Application.Response
{
    public class SearchResultsHistoryResponse
    {
        public IEnumerable<SearchResult> SearchHistories { get; set; }
    }
}
