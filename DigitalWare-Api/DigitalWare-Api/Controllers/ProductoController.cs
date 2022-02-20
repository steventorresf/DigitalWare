using DigitalWare_Api_Dto;
using DigitalWare_Api_Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoFacade _productoFacade;

        public ProductoController(IProductoFacade productoFacade)
        {
            this._productoFacade = productoFacade;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductoDto request)
        {
            var response = await _productoFacade.Create(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productoFacade.Delete(id);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productoFacade.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productoFacade.GetById(id);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProductoDto request)
        {
            var response = await _productoFacade.Update(request);
            return Ok(response);
        }
    }
}
