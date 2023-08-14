using System.Text.RegularExpressions;
using System.Web;
using WebScrapper.Core.Models;

namespace WebScrapper.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchEngineDataService _searchEngineDataService;
        public SearchService(ISearchEngineDataService searchEngineDataService)
        {
            _searchEngineDataService = searchEngineDataService;
        }

        public async Task<IEnumerable<SearchEngine>> GetSearchEnginesAsync()
        {
            var searchEngines = await _searchEngineDataService.GetAllSearchEnginesAsync();
            return searchEngines.Select(x => new SearchEngine()
            {
                Id = x.Id,
                Title = x.Title
            });
        }

        public async Task<List<int>> GetSearchRankingsAsync(string searchText, int searchEngineId, int numResultsToSearchIn)
        {
            var searchEngine = await  _searchEngineDataService.GetByIdAsync(searchEngineId);
            if (searchEngine == null) return new List<int>();

            var searchUrl = searchEngine.SearchUrl.Replace("#SearchText#", HttpUtility.UrlEncode(searchText)).Replace("#NumberResultsToSearchIn#", numResultsToSearchIn.ToString());

            using var client = new HttpClient();
            if (searchEngine.BaseUrl.ToLower().Contains("bing"))
            {
                client.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");
            }

            var response = HttpUtility.HtmlDecode(await client.GetStringAsync($"{searchEngine.BaseUrl}/{searchUrl}"));
            var links = RetrieveLinksFromResponse(response, searchEngine.ResultExtractionExpression);
            var rankingList = (from link in links where link.Contains("infotrack.co.uk", StringComparison.OrdinalIgnoreCase) select links.IndexOf(link)).Distinct().ToList();
            return rankingList;
        }

        public List<string> RetrieveLinksFromResponse(string responseBody, string regexToExtractLinks)
        {
            var matches = Regex.Matches(responseBody, $"{regexToExtractLinks}");
            return matches.Select(x => x.Value).ToList();
        }
    }
}
