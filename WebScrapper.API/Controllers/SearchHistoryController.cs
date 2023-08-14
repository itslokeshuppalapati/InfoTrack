using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebScrapper.API.Core;
using WebScrapper.Application.Queries;

namespace WebScrapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllersBase
    {
        public SearchHistoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Ok(new GetSearchResultsHistoryQuery());
            return result;
        }
    }
}
