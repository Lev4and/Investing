using Investing.Infrastructure.Queries;
using Investing.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Investing.ResourceWebApplication.Areas.Bcs.Controllers
{
    [Area("Bcs")]
    [ApiController]
    [Route("api/bcs/dividends")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class DividendsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DividendsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{securCode}")]
        public async Task<IActionResult> GetHistoryDividendsAsync([FromRoute(Name = "securCode")][Required] 
            string securCode)
        {
            if (string.IsNullOrEmpty(securCode)) return BadRequest($"The {nameof(securCode)} should be not " +
                $"null or empty.");

            return Ok(await _mediator.Send(new GetBcsDividends(securCode)));
        }
    }
}
