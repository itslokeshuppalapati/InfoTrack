using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public interface ISearchEngineDataService
    {
        Task<IEnumerable<SearchEngine>> GetAllSearchEnginesAsync();

        Task<SearchEngine> GetByIdAsync(int id);
    }
}
