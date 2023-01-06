using Investing.HttpClients.Resource.Import.RequestModels;
using Investing.Infrastructure.Commands;
using Investing.ResourceWebApplication.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Investing.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [Route("api/import/dividend")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class DividendController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DividendController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportDividendsAsync([FromBody][Required] ImportBcsDividendsModel model)
        {
            if (model == null) return BadRequest($"The {nameof(model)} should be not null.");

            return Ok(await _mediator.Send(new ImportBcsDividend(model)));
        }
    }
}
