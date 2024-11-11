using DAL.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Practica
{
    public class PracticaService : IPracticaService
    {
        private readonly IPracticaRepository _repository;

        public PracticaService(IPracticaRepository repo)
        {
            _repository = repo;
        }

        public async Task<object> CompareSalesPerYear()
        {
            return await _repository.CompareSalesPerYear();
        }

        public async Task<object> CustomersWithHighValueOrders()
        {
            return await _repository.CustomersWithHighValueOrders();
        }

        public async Task<object> CustomersWithoutOrdersInLastMonth()
        {
            return await _repository.CustomersWithoutOrdersInLastMonth();
        }

        public async Task<object> EmployeesOrdersCustomersFrom5Countries()
        {
            return await _repository.EmployeesOrdersCustomersFrom5Countries();
        }

        public async Task<object> GetDataFromPurchase()
        {
            return await _repository.GetDataFromPurchase();
        }

        public async Task<object> GetDiscontinuedProducts()
        {
            return await _repository.GetDiscontinuedProducts();
        }

        public async Task<object> GetPurchaseQuantityByCustomer()
        {
            return await _repository.GetPurchaseQuantityByCustomer();
        }

        public async Task<object> ProductsDecliningSales()
        {
            return await _repository.ProductsDecliningSales();
        }

        public async Task<object> ProductsMoreThanOneCategory()
        {
            return await _repository.ProductsMoreThanOneCategory();
        }

        public async Task<object> ProfitMarginByCategory()
        {
            return await _repository.ProfitMarginByCategory();
        }

        public async Task<object> QuantityOrdersByMonth(DateTime month)
        {
            return await _repository.QuantityOrdersByMonth(month);
        }
    }
}
