using MediatR;
using WebScrapper.Application.Queries;
using WebScrapper.Application.Response;
using WebScrapper.Core.Services;

namespace WebScrapper.Application.Handlers
{
    public class GetSearchRankingsQueryHandler : IRequestHandler<GetSearchRankingsQuery, SearchRankingResponse>
    {
        private readonly ISearchService _searchService;
        private readonly ISearchHistoryDataService _searchHistoryDataService;
        private readonly ISearchEngineDataService _searchEngineDataService;

        public GetSearchRankingsQueryHandler(ISearchService searchService, ISearchHistoryDataService searchHistoryDataService, ISearchEngineDataService searchEngineDataService)
        {
            _searchService = searchService;
            _searchHistoryDataService = searchHistoryDataService;
            _searchEngineDataService = searchEngineDataService;
        }

        public async Task<SearchRankingResponse> Handle(GetSearchRankingsQuery request, CancellationToken cancellationToken)
        {
            var searchRankings = await _searchService.GetSearchRankingsAsync(request.SearchText, request.SearchEngineId, request.NumberOfResultsToSearchIn);
            if (searchRankings.Count > 0)
            {
                var searchEngine = await _searchEngineDataService.GetByIdAsync(request.SearchEngineId);
                await _searchHistoryDataService.InsertSearchHistoryAsync(searchRankings, request.SearchText, searchEngine.BaseUrl);
            }

            return new SearchRankingResponse()
            {
                SearchRankings = searchRankings
            };
        }
    }
}
