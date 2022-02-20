using DigitalWare_Api_Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaFacade _consultaFacade;

        public ConsultasController(IConsultaFacade consultaFacade)
        {
            this._consultaFacade = consultaFacade;
        }

        [HttpGet("ListadoClientesNoMayores")]
        public async Task<IActionResult> GetListadoClientesNoMayores()
        {
            var response = await _consultaFacade.GetListadoClientesNoMayores();
            return Ok(response);
        }

        [HttpGet("ListadoPreciosProductos")]
        public async Task<IActionResult> GetListadoPreciosProductos()
        {
            var response = await _consultaFacade.GetListadoPreciosProductos();
            return Ok(response);
        }

        [HttpGet("ListadoProductosExistenciaMinima")]
        public async Task<IActionResult> GetListadoProductosExistenciaMinima()
        {
            var response = await _consultaFacade.GetListadoProductosExistenciaMinima();
            return Ok(response);
        }

        [HttpGet("ListadoTotalVendidoPorProducto")]
        public async Task<IActionResult> GetListadoTotalVendidoPorProducto(int anio)
        {
            var response = await _consultaFacade.GetListadoTotalVendidoPorProducto(anio);
            return Ok(response);
        }

        [HttpGet("UltimaFechaCompraCliente")]
        public async Task<IActionResult> GetUltimaFechaCompraCliente(int idCliente)
        {
            var response = await _consultaFacade.GetUltimaFechaCompraCliente(idCliente);
            return Ok(response);
        }
    }
}
