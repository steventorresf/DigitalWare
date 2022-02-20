using DigitalWare_Api_Dto;
using DigitalWare_Api_Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWare_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteFacade _clienteFacade;

        public ClienteController(IClienteFacade clienteFacade)
        {
            this._clienteFacade = clienteFacade;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ClienteDto request)
        {
            var response = await _clienteFacade.Create(request);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clienteFacade.Delete(id);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _clienteFacade.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _clienteFacade.GetById(id);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ClienteDto request)
        {
            var response = await _clienteFacade.Update(request);
            return Ok(response);
        }
    }
}
