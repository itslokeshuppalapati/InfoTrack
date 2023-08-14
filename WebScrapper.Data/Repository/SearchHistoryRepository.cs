using System.Globalization;
using Microsoft.EntityFrameworkCore;
using WebScrapper.Core.Models;
using WebScrapper.Core.Services;
using WebScrapper.Data.Data;
using WebScrapper.Data.Models;

namespace WebScrapper.Data.Repository
{
    public class SearchHistoryRepository : ISearchHistoryDataService
    {
        private readonly AppDbContext _dbContext;

        public SearchHistoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SearchResult>> GetAllSearchHistoriesAsync()
        {
            var searchResults = await _dbContext.SearchResults.ToListAsync();
            return searchResults.Select(x => new SearchResult()
            {
                Id = x.Id,
                KeyWords = x.KeyWords,
                Ranking = x.Ranking,
                SearchDate = x.SearchDate.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture),
                Url = x.Url
            }).OrderByDescending(x => x.SearchDate).ToList();
        }

        public async Task InsertSearchHistoryAsync(List<int> rankings, string keywords, string url)
        {
            var searchResult = new SearchResults()
            {
                Ranking = string.Join(",", rankings.Select(x => x.ToString())),
                SearchDate = DateTime.Now,
                KeyWords = keywords,
                Url = url
            };

            var entity = await _dbContext.SearchResults.AddAsync(searchResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}
