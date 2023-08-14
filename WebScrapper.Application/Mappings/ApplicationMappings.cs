using AutoMapper;
using WebScrapper.Application.Response;
using WebScrapper.Core.Models;

namespace WebScrapper.Application.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateSearchEnginesToSearchEnginesResponse();
            CreateSearchRankingToSearchRankingResponse();
        }

        private void CreateSearchRankingToSearchRankingResponse()
        {
        }

        private void CreateSearchEnginesToSearchEnginesResponse()
        {
            CreateMap<List<SearchEngine>, SearchEnginesResponse>();
        }
    }
}
