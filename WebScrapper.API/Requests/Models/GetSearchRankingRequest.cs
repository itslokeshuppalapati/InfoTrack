using MediatR;

namespace WebScrapper.API.Requests.Models
{
    public class GetSearchRankingRequest : IRequest<SearchRankingResponse>
    {
        public GetSearchRankingRequest(string searchText, string searchEngine, string searchUrl)
        {
            SearchText = searchText;
            SearchEngine = searchEngine;
            SearchUrl = searchUrl;
        }

        public string SearchText { get; set; }

        public string SearchEngine { get; set; }

        public string SearchUrl { get; set; }
    }
}
