using AutoMapper;
using MediatR;
using WebScrapper.API.Models.Search;
using WebScrapper.API.Requests.Models;
using WebScrapper.Core.Models;
using WebScrapper.Core.Services;

namespace WebScrapper.API.Requests.Handlers
{
    public class GetSearchRankingsRequestHandler : IRequestHandler<GetSearchRankingRequest, SearchRankingResponse>
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public GetSearchRankingsRequestHandler(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<SearchRankingResponse> Handle(GetSearchRankingRequest request, CancellationToken cancellationToken)
        {
            var searchRankings = await _searchService.SearchAsync(request.SearchText, request.SearchUrl);
            return _mapper.Map<SearchRankingResponse>(searchRankings);
        }
    }
}
