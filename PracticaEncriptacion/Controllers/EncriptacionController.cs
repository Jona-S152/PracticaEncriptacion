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

        [HttpGet("QuantityOrdersByMonth")]
        public async Task<IActionResult> QuantityOrdersByMonth(DateTime date)
        {
            var result = await _service.QuantityOrdersByMonth(date);

            return Ok(result);
        }

        [HttpGet("GetProfitMarginByCategory")]
        public async Task<IActionResult> ProfitMarginByCategory()
        {
            var result = await _service.ProfitMarginByCategory();

            return Ok(result);
        }

        [HttpGet("GetProductsMoreThanOneCategory")]
        public async Task<IActionResult> ProductsMoreThanOneCategory()
        {
            var result = await _service.ProductsMoreThanOneCategory();

            return Ok(result);
        }

        [HttpGet("GetCustomersWithoutOrdersInLastMonth")]
        public async Task<IActionResult> CustomersWithoutOrdersInLastMonth()
        {
            var result = await _service.CustomersWithoutOrdersInLastMonth();

            return Ok(result);
        }

        [HttpGet("CompareSalesPerYear")]
        public async Task<IActionResult> CompareSalesPerYear()
        {
            var result = await _service.CompareSalesPerYear();

            return Ok(result);
        }

        [HttpGet("EmployeesOrdersCustomersFrom5Countries")]
        public async Task<IActionResult> EmployeesOrdersCustomersFrom5Countries()
        {
            var result = await _service.EmployeesOrdersCustomersFrom5Countries();

            return Ok(result);
        }

        [HttpGet("GetCustomersWithHighValueOrders")]
        public async Task<IActionResult> CustomersWithHighValueOrders()
        {
            var result = await _service.CustomersWithHighValueOrders();

            return Ok(result);
        }

        [HttpGet("ProductsDecliningSales")]
        public async Task<IActionResult> ProductsDecliningSales()
        {
            var result = await _service.ProductsDecliningSales();

            return Ok(result);
        }
    }
}
