using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebScrapper.API.Core;
using WebScrapper.Application.Queries;

namespace WebScrapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllersBase
    {
        public SearchController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("Rankings")]
        public async Task<IActionResult> Search(string searchText, int searchEngineId, int pageSize)
        {
            var result = await Ok(new GetSearchRankingsQuery(searchText, searchEngineId, pageSize));
            return result;
        }

        [HttpGet("SearchEngines")]
        public async Task<IActionResult> GetSearchEngines()
        {
            var result = await Ok(new GetSearchEnginesQuery());
            return result;
        }
    }
}
