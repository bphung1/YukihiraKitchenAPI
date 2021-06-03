using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using YukihiraKitchen.Application.Core;

namespace YukihiraKitchen.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : Controller
    {
        private IMediator _mediator;

        //if _mediator is null, assign Mediator to whatever is to the right of ??=
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound();
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
