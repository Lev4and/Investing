using Investing.EntityFramework.Abstracts;
using Investing.EntityFramework.Infrastructure.Factories;
using Investing.HttpClients.BcsApi.ResponseModels;
using Investing.ResourceWebApplication.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Investing.ResourceWebApplication.Areas.Import.Controllers
{
    [Area("Import")]
    [ApiController]
    [Route("api/import/product")]
    [EnableCors(CorsExtensions.CorsPolicyName)]
    public class ProductController : ControllerBase
    {
        private readonly IImporterVisitor _importer;

        public ProductController(IImporterVisitor importer)
        {
            _importer = importer;
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromBody] Partner partner)
        {
            if (partner == null) return BadRequest();

            var factory = new ProductFactory();
            var product = factory.Create(partner);

            await product.ImportAsync(_importer);

            return Ok(product.Id);
        }
    }
}
