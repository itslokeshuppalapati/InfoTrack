using MediatR;
using WebScrapper.Application.Response;

namespace WebScrapper.Application.Queries
{
    public class GetSearchEnginesQuery : IRequest<SearchEnginesResponse>
    {
    }
}
