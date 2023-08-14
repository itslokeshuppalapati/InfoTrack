using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebScrapper.API.Core
{
    public class ControllersBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ControllersBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Ok<TResponse>(IRequest<TResponse> query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
