using Investing.HttpClients.BcsApi.RequestModels;
using Investing.HttpClients.Facades;
using Investing.ResourceWebApplication.Extensions;
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
        private readonly IBcsFacade _bcs;

        public QuotationsController(IBcsFacade bcs)
        {
            _bcs = bcs;
        }

        [HttpGet]
        [Route("{securCode}/{classCode}")]
        public async Task<IActionResult> GetQuotationsAsync([FromRoute(Name = "securCode")] string securCode,
            [FromRoute(Name = "classCode")] string classCode, [FromQuery(Name = "from")][Required] DateTime from,
            [FromQuery(Name = "to")][Required] DateTime to, 
            [FromQuery(Name = "resolution")][Required] QuotationResolution resolution)
        {
            if (string.IsNullOrEmpty(securCode)) return BadRequest();
            if (string.IsNullOrEmpty(classCode)) return BadRequest();
            if (from > to) return BadRequest();
            if (to < from) return BadRequest();

            return Ok(await _bcs.GetHistoryQuotationsAsync(new GetHistoryQuotationsModel(securCode, classCode, from,
                to, resolution)));
        }
    }
}
