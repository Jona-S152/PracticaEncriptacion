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
    }
}
