using MediatR;
using WebScrapper.Application.Queries;
using WebScrapper.Application.Response;
using WebScrapper.Core.Services;

namespace WebScrapper.Application.Handlers
{
    public class GetSearchResultsHistoryQueryHandler : IRequestHandler<GetSearchResultsHistoryQuery, SearchResultsHistoryResponse>
    {
        private readonly ISearchHistoryService _searchHistoryService;

        public GetSearchResultsHistoryQueryHandler(ISearchHistoryService searchHistoryService)
        {
            _searchHistoryService = searchHistoryService;
        }

        public async Task<SearchResultsHistoryResponse> Handle(GetSearchResultsHistoryQuery request, CancellationToken cancellationToken)
        {
            var searchHistories = await _searchHistoryService.GetAllSearchHistoryAsync();
            return new SearchResultsHistoryResponse()
            {
                SearchHistories = searchHistories
            };
        }
    }
}
