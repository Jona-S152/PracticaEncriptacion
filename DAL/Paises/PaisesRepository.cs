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

        public async Task<ResponseJson> Delete(int id)
        {
            try
            {
                Paise paisFound = await _context.Paises.FirstOrDefaultAsync(p => p.Id == id);

                if (paisFound == null) return new ResponseJson("El país no se encuentra registrado", null, true);

                _context.Paises.Remove(paisFound);
                await _context.SaveChangesAsync();

                return new ResponseJson(MessageResponse.SuccessfulDeleting, null, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
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

        public async Task<ResponseJson> Insert(Paise pais)
        {
            try
            {
                bool isExist = await _context.Paises.AnyAsync(p => p.Id == pais.Id || p.Nombre == pais.Nombre || p.CodigoPais == pais.CodigoPais);

                if (isExist) return new ResponseJson("El país ya se encuentra registrado", null, true);

                await _context.Paises.AddAsync(pais);
                await _context.SaveChangesAsync();

                return new ResponseJson(MessageResponse.SuccessfulRegistration, null, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> Update(Paise pais, int id)
        {
            try
            {
                Paise paisFound = await _context.Paises.FirstOrDefaultAsync(p => p.Id == id);

                if (paisFound == null) return new ResponseJson("El país no se encuentra registrado", null, true);

                paisFound.Id = pais.Id;
                paisFound.Nombre = pais.Nombre;
                paisFound.Acronimo = pais.Acronimo;
                paisFound.CodigoPais = pais.CodigoPais;

                _context.Paises.Update(paisFound);
                await _context.SaveChangesAsync();

                return new ResponseJson(MessageResponse.SuccessfulUpdating, null, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }
    }
}
