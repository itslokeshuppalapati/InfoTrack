using AutoMapper;
using MediatR;
using WebScrapper.API.Models.Search;
using WebScrapper.API.Requests.Models;
using WebScrapper.Core.Services;

namespace WebScrapper.API.Requests.Handlers
{
    public class GetSearchEnginesRequestHandler : IRequestHandler<GetSearchEnginesRequest, SearchEnginesResponse>
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;
        public GetSearchEnginesRequestHandler(IMapper mapper, ISearchService searchService)
        {
            _mapper = mapper;
            _searchService = searchService;
        }

        public async Task<SearchEnginesResponse> Handle(GetSearchEnginesRequest request, CancellationToken cancellationToken)
        {
            var searchEngines = _searchService.GetSearchEngines();
            return _mapper.Map<SearchEnginesResponse>(searchEngines);
        }
    }
}
