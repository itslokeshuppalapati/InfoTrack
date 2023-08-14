using MediatR;

namespace WebScrapper.API.Requests.Models
{
    public class GetSearchEnginesRequest : IRequest<SearchEnginesResponse>
    {
    }
}
