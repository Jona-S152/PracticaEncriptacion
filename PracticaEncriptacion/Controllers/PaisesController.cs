using BLL.Paises;
using DAL.Paises;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaEncriptacion.EndPoints;

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

        [HttpGet(ApiRoutes.Paises.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            ResponseJson response = await _paisesService.GetAll();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Paises.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            ResponseJson response = await _paisesService.GetById(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Paises.GetByAcronimo)]
        public async Task<IActionResult> GetByAcronimo(string acronimo)
        {
            ResponseJson response = await _paisesService.GetByAcronimo(acronimo);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Paises.GetByAcronimoStartsWith)]
        public async Task<IActionResult> GetByAcronimoStartsWith(string acronimo)
        {
            ResponseJson response = await _paisesService.GetByAcronimoStartsWith(acronimo);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Paises.GetOrderByAcronimoDESC)]
        public async Task<IActionResult> GetOrderByAcronimoDESC()
        {
            ResponseJson response = await _paisesService.GetOrderByAcronimoDESC();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Paises.Add)]
        public async Task<IActionResult> Add([FromBody] Paise pais)
        {
            ResponseJson response = await _paisesService.Insert(pais);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Paises.Update)]
        public async Task<IActionResult> Update([FromBody] Paise pais, int id)
        {
            ResponseJson response = await _paisesService.Update(pais, id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }
    }
}
