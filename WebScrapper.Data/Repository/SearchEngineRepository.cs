using Microsoft.EntityFrameworkCore;
using WebScrapper.Core.Models;
using WebScrapper.Core.Services;
using WebScrapper.Data.Data;

namespace WebScrapper.Data.Repository
{
    public class SearchEngineRepository : ISearchEngineDataService
    {
        private readonly AppDbContext _dbContext;

        public SearchEngineRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SearchEngine>> GetAllSearchEnginesAsync()
        {
            var searchEngines = await _dbContext.SearchEngines.ToListAsync();

            return searchEngines.Select(x => new SearchEngine()
            {
                Id = x.Id,
                Title = x.Title
            });
        }

        public async Task<SearchEngine> GetByIdAsync(int id)
        {
            var searchEngine = await _dbContext.SearchEngines.FindAsync(id);

            if (searchEngine == null) return null;

            return new SearchEngine()
            {
                Id = searchEngine.Id,
                BaseUrl = searchEngine.BaseUrl,
                ResultExtractionExpression = searchEngine.ResultExtractionExpression,
                SearchUrl = searchEngine.SearchUrl
            };
        }
    }
}
