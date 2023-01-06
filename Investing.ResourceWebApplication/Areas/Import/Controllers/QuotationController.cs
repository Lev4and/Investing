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
        public async Task<IActionResult> ImportQuotationAsync([FromBody][Required] ImportBcsQuotationModel model)
        {
            if (model == null) return BadRequest($"The {nameof(model)} should be not null.");

            return Ok(await _mediator.Send(new ImportBcsQuotation(model)));
        }
    }
}
