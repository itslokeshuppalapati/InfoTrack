using MediatR;
using WebScrapper.Application.Response;

namespace WebScrapper.Application.Queries
{
    public class GetSearchRankingsQuery : IRequest<SearchRankingResponse>
    {
        public GetSearchRankingsQuery(string searchText, int searchEngineId, int numResultsToSearchIn)
        {
            SearchText = !string.IsNullOrEmpty(searchText) && !string.IsNullOrWhiteSpace(searchText) ? searchText : throw new ArgumentException("searchText missing");
            SearchEngineId = searchEngineId;
            NumberOfResultsToSearchIn = numResultsToSearchIn > 0 ? numResultsToSearchIn : 100;
        }

        public string SearchText { get; set; }

        public Uri SearchUrl { get; set; }

        public int NumberOfResultsToSearchIn { get; set; }
        public int SearchEngineId { get; set; }
    }
}
