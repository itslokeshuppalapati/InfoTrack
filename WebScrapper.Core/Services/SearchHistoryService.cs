using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly ISearchHistoryDataService _searchHistoryDataService;
        public SearchHistoryService(ISearchHistoryDataService searchHistoryDataService)
        {
            _searchHistoryDataService = searchHistoryDataService;
        }

        public async Task<IEnumerable<SearchResult>> GetAllSearchHistoryAsync()
        {
            var results = await _searchHistoryDataService.GetAllSearchHistoriesAsync();
            return results;
        }
    }
}
