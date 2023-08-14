using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public interface ISearchHistoryDataService
    {
        Task<IEnumerable<SearchResult>> GetAllSearchHistoriesAsync();

        Task InsertSearchHistoryAsync(List<int> rankings, string keywords, string url);
    }
}
