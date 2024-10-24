using BLL.Common;
using DAL.Capitales;
using Entities;
using Entities.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Capitales
{
    public class CapitalesService : ICapitalesService
    {
        private readonly ICapitalesRepository _capitalesRepository;

        public CapitalesService(ICapitalesRepository repo)
        {
            _capitalesRepository = repo;
        }

        public async Task<ResponseJson> GetAll()
        {
            try
            {
                List<Capital> capitales = await _capitalesRepository.GetAll();

                if (capitales.Count == 0) return new ResponseJson(MessageResponse.CapitalsNotFound, null, true);

                return new ResponseJson(MessageResponse.CapitalLst, capitales, false);
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
                Capital capital = await _capitalesRepository.GetById(id);

                if (capital == null) return new ResponseJson(MessageResponse.CapitalNotFound, null, true);

                return new ResponseJson(MessageResponse.Capital, capital, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> GetByPostalCode(string postalCode)
        {
            try
            {
                Capital capital = await _capitalesRepository.GetByPostalCode(postalCode);

                if (capital == null) return new ResponseJson(MessageResponse.CapitalNotFound, null, true);

                return new ResponseJson(MessageResponse.Capital, capital, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> GetByPostalCodeStartsWith(string characters)
        {
            try
            {
                List<Capital> capitales = await _capitalesRepository.GetAll();

                if (capitales.Count == 0) return new ResponseJson(MessageResponse.CapitalsNotFound, null, true);
                
                capitales = capitales.Where(c => c.CodigoPostal.StartsWith(characters, StringComparison.OrdinalIgnoreCase)).ToList();

                return new ResponseJson(MessageResponse.CapitalLst, capitales, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }

        public async Task<ResponseJson> Insert(Capital capital)
        {
            try
            {
                bool isSuccessfulInsert = await _capitalesRepository.Insert(capital);

                if (!isSuccessfulInsert) return new ResponseJson(MessageResponse.RegistrationFailed, null, true);

                return new ResponseJson(MessageResponse.SuccessfulRegistration, null, false);
            }
            catch (Exception ex)
            {
                return new ResponseJson(ex.Message, null, true);
            }
        }
    }
}
