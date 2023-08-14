using MediatR;
using WebScrapper.Application.Queries;
using WebScrapper.Application.Response;
using WebScrapper.Core.Services;

namespace WebScrapper.Application.Handlers
{
    public class GetSearchEnginesQueryHandler : IRequestHandler<GetSearchEnginesQuery, SearchEnginesResponse>
    {
        private readonly ISearchService _searchService;
        public GetSearchEnginesQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<SearchEnginesResponse> Handle(GetSearchEnginesQuery request, CancellationToken cancellationToken)
        {
            var searchEngines = await  _searchService.GetSearchEnginesAsync();
            return new SearchEnginesResponse()
            {
                SearchEngines = searchEngines.ToList()
            };
        }
    }
}