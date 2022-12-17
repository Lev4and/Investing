using Investing.HttpClients.Facades;
using Investing.ResourceWebApplication.Extensions;
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
        private readonly IBcsFacade _bcs;

        public PartnersController(IBcsFacade bcs)
        {
            _bcs = bcs;
        }

        [HttpGet]
        public async Task<IActionResult> GetPartnersAsync([FromQuery(Name = "offset")][Required] int offset)
        {
            if (offset < 0) return BadRequest();

            return Ok(await _bcs.GetPartnerQuotationsAsync(offset));
        }
    }
}
