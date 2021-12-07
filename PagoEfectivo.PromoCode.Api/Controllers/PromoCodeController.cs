using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagoEfectivo.PromoCode.Domain.Interfaces;
using PagoEfectivo.PromoCode.Model.Requests;
using System.Net;
using System.Threading.Tasks;

namespace PagoEfectivo.PromoCode.Api.Controllers
{
    [Route("api/promo-code")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly ILogger<PromoCodeController> _logger;
        private readonly IPromoCodeService _service;
        public PromoCodeController(ILogger<PromoCodeController> logger, IPromoCodeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> All()
        {
            var items = await _service.All();
            return Ok(items);
        }

        [HttpPost]
        [Route("generate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Generate(GenerateRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Generate(model);
                return Ok(result);
            }

            return new JsonResult("Ocurrió un error.") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("redeem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Redeem(RedeemRequest model)
        {
            //if (model.code == null)
            //    return BadRequest();

            return Ok(await _service.Redeem(model));
        }
    }
}
