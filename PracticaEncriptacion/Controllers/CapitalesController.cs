using BLL.Capitales;
using Entities;
using Entities.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaEncriptacion.EndPoints;

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

        [HttpGet(ApiRoutes.Capitales.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            ResponseJson response = await _capitalesService.GetAll();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Capitales.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseJson response = await _capitalesService.GetById(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Capitales.GetByPostalCode)]
        public async Task<IActionResult> GetByPostalCode(string postalCode)
        {
            ResponseJson response = await _capitalesService.GetByPostalCode(postalCode);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Capitales.GetByPostalCodeStartsWith)]
        public async Task<IActionResult> GetByPostalCodeStartsWith(string searchTerm)
        {
            ResponseJson response = await _capitalesService.GetByPostalCodeStartsWith(searchTerm);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Capitales.Add)]
        public async Task<IActionResult> Add([FromBody] Capital capital)
        {
            ResponseJson response = await _capitalesService.Insert(capital);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Capitales.Update)]
        public async Task<IActionResult> Update([FromBody] Capital capital, int id)
        {
            ResponseJson response = await _capitalesService.Update(capital, id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }
    }
}
