using BLL.Practica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticaEncriptacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncriptacionController : ControllerBase
    {
        private readonly IPracticaService _service;

        public EncriptacionController(IPracticaService service)
        {
            _service = service;
        }

        [HttpGet("GetDiscontinuedProducts")]
        public async Task<IActionResult> GetDiscontinuedProducts()
        {
            var result = await _service.GetDiscontinuedProducts();

            return Ok(result);
        }

        [HttpGet("GetDataFromPurchase")]
        public async Task<IActionResult> GetDataFromPurchase()
        {
            var result = await _service.GetDataFromPurchase();

            return Ok(result);
        }

        [HttpGet("GetPurchaseQuantityByCustomer")]
        public async Task<IActionResult> GetPurchaseQuantityByCustomer()
        {
            var result = await _service.GetPurchaseQuantityByCustomer();

            return Ok(result);
        }
    }
}
