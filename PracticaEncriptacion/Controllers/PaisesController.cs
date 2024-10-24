using BLL.Paises;
using DAL.Paises;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaEncriptacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisesService _paisesService;

        public PaisesController(IPaisesService service)
        {
            _paisesService = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseJson response = await _paisesService.GetAll();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseJson response = await _paisesService.GetById(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetByAcronimo/{acronimo}")]
        public async Task<IActionResult> GetByAcronimo(string acronimo)
        {
            ResponseJson response = await _paisesService.GetByAcronimo(acronimo);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetByAcronimoStartsWith/{acronimo}")]
        public async Task<IActionResult> GetByAcronimoStartsWith(string acronimo)
        {
            ResponseJson response = await _paisesService.GetByAcronimoStartsWith(acronimo);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetOrderByAcronimoDESC")]
        public async Task<IActionResult> GetOrderByAcronimoDESC()
        {
            ResponseJson response = await _paisesService.GetOrderByAcronimoDESC();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }
    }
}
