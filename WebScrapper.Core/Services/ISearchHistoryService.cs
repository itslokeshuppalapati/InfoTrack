using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public interface ISearchHistoryService
    {
        Task<IEnumerable<SearchResult>> GetAllSearchHistoryAsync();
    }
}
