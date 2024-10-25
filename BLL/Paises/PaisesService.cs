using DAL.Paises;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Paises
{
    public class PaisesService : IPaisesService
    {
        private readonly IPaisesRepository _paisesRepository;

        public PaisesService(IPaisesRepository repo)
        {
            _paisesRepository = repo;
        }

        public async Task<ResponseJson> GetAll()
        {
            return await _paisesRepository.GetAll();
        }

        public async Task<ResponseJson> GetByAcronimo(string acronimo)
        {
            return await _paisesRepository.GetByAcronimo(acronimo);
        }

        public async Task<ResponseJson> GetByAcronimoStartsWith(string acronimo)
        {
            ResponseJson response = await _paisesRepository.GetAll();

            List<Paise> paises = (List<Paise>)response.Data;

            paises = paises.Where(p => p.Acronimo.StartsWith(acronimo, StringComparison.OrdinalIgnoreCase)).ToList();

            response.Data = paises;

            return response;
        }

        public async Task<ResponseJson> GetById(int id)
        {
            return await _paisesRepository.GetById(id);
        }

        public async Task<ResponseJson> GetOrderByAcronimoDESC()
        {
            ResponseJson response = await _paisesRepository.GetAll();

            List<Paise> paises = (List<Paise>)response.Data;

            paises = paises.OrderByDescending(p => p.Acronimo).ToList();

            response.Data = paises;

            return response;
        }

        public async Task<ResponseJson> Insert(Paise pais)
        {
            return await _paisesRepository.Insert(pais);
        }

        public async Task<ResponseJson> Update(Paise pais, int id)
        {
            return await _paisesRepository.Update(pais, id);
        }
    }
}
