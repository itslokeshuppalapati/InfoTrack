using MediatR;
using WebScrapper.Application.Response;

namespace WebScrapper.Application.Queries
{
    public class GetSearchResultsHistoryQuery : IRequest<SearchResultsHistoryResponse>
    {
    }
}
