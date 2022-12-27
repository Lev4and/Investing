using Investing.HttpClients.BcsApi.RequestModels;
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
    [Route("api/bcs/quotations")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class QuotationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuotationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{securCode}/{classCode}")]
        public async Task<IActionResult> GetQuotationsAsync([FromRoute(Name = "securCode")] string securCode,
            [FromRoute(Name = "classCode")] string classCode, [FromQuery(Name = "from")][Required] DateTime from,
            [FromQuery(Name = "to")][Required] DateTime to, 
            [FromQuery(Name = "resolution")][Required] QuotationResolution resolution)
        {
            if (string.IsNullOrEmpty(securCode)) return BadRequest($"The {nameof(securCode)} should be not " +
                $"null or empty.");
            if (string.IsNullOrEmpty(classCode)) return BadRequest($"The {nameof(classCode)} should be not " +
                $"null or empty.");
            if (from > to) return BadRequest($"The {nameof(from)} should be less than {nameof(to)}");
            if (to < from) return BadRequest($"The {nameof(to)} should be greater than {nameof(from)}");

            return Ok(await _mediator.Send(new GetBcsQuotations(new GetHistoryQuotationsModel(securCode, classCode, 
                from, to, resolution))));
        }
    }
}
