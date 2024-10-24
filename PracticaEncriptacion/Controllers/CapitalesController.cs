using BLL.Capitales;
using Entities;
using Entities.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaEncriptacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapitalesController : ControllerBase
    {
        private readonly ICapitalesService _capitalesService;

        public CapitalesController(ICapitalesService service)
        {
            _capitalesService = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ResponseJson response = await _capitalesService.GetAll();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseJson response = await _capitalesService.GetById(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetByPostalCode/{postalCode}")]
        public async Task<IActionResult> GetByPostalCode(string postalCode)
        {
            ResponseJson response = await _capitalesService.GetByPostalCode(postalCode);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetByPostalCodeStartsWith/{searchTerm}")]
        public async Task<IActionResult> GetByPostalCodeStartsWith(string searchTerm)
        {
            ResponseJson response = await _capitalesService.GetByPostalCodeStartsWith(searchTerm);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Capital capital)
        {
            ResponseJson response = await _capitalesService.Insert(capital);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }
    }
}
