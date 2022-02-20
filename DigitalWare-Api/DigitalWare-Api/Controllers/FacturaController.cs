using DigitalWare_Api_Dto;
using DigitalWare_Api_Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaFacade _facturaFacade;

        public FacturaController(IFacturaFacade facturaFacade)
        {
            this._facturaFacade = facturaFacade;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FacturaDto request)
        {
            var response = await _facturaFacade.Create(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _facturaFacade.Delete(id);
            return Ok(response);
        }

        [HttpGet("GetByNoFactura/{noFactura}")]
        public async Task<IActionResult> GetByNoFactura(int noFactura)
        {
            var response = await _facturaFacade.GetByNoFactura(noFactura);
            return Ok(response);
        }
    }
}
