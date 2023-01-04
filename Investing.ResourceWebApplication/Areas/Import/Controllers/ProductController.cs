using Investing.HttpClients.BcsApi.ResponseModels;
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
    [Route("api/import/product")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody][Required] PartnerBase partner)
        {
            if (partner == null) return BadRequest($"The {nameof(partner)} should be not null.");

            return Ok(await _mediator.Send(new ImportBcsPartner(partner)));
        }
    }
}
