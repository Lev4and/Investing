using Investing.Infrastructure.Commands;
using Investing.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Investing.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [Route("api/import/quotation")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class QuotationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuotationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportQuotation([FromBody] ImportBcsQuotation command)
        {
            if (command == null) return BadRequest($"The {nameof(command)} should be not null.");

            return Ok(await _mediator.Send(command));
        }
    }
}
