using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchEngine>> GetSearchEnginesAsync();

        Task<List<int>> GetSearchRankingsAsync(string searchText, int searchEngineId, int numResultsToSearchIn);
    }
}
