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
    [Route("api/bcs/partners")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class PartnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPartnersAsync([FromQuery(Name = "offset")][Required] int offset)
        {
            if (offset < 0) return BadRequest($"{nameof(offset)} should at greater than or equal to 0.");

            return Ok(await _mediator.Send(new GetBcsPartners(offset)));
        }
    }
}
