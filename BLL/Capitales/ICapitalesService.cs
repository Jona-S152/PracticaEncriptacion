using Entities;
using Entities.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Capitales
{
    public interface ICapitalesService
    {
        public Task<ResponseJson> GetAll();
        public Task<ResponseJson> GetById(int id);
        public Task<ResponseJson> GetByPostalCode(string postalCode);
        public Task<ResponseJson> GetByPostalCodeStartsWith(string characters);
        public Task<ResponseJson> Insert(Capital capital);
        public Task<ResponseJson> Update(Capital capital, int id);
    }
}
