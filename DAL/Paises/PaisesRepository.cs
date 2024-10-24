using DAL.Common;
using DAL.Context;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Paises
{
    public class PaisesRepository : IPaisesRepository
    {
        private readonly ApplicationContext _context;

        public PaisesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ResponseJson> GetAll()
        {
            try
            {
                List<Paise> countries = await _context.Paises.ToListAsync();

                if (countries.Count == 0) return new ResponseJson(MessageResponse.CountriesNotFound, null, true);

                return new ResponseJson(MessageResponse.CountryList, countries, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> GetByAcronimo(string acronimo)
        {
            try
            {
                Paise pais = await _context.Paises.FirstOrDefaultAsync(p => p.Acronimo == acronimo);

                if (pais == null) return new ResponseJson(MessageResponse.CountryNotFound, null, true);

                return new ResponseJson(MessageResponse.Country, pais, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> GetById(int id)
        {
            try
            {
                Paise pais = await _context.Paises.FirstOrDefaultAsync(p => p.Id == id);

                if (pais == null) return new ResponseJson(MessageResponse.CountryNotFound, null, true);

                return new ResponseJson(MessageResponse.Country, pais, false);
            }
            catch(Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }
    }
}
