using Entities.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Capitales
{
    public interface ICapitalesRepository
    {
        public Task<List<Capital>> GetAll();
        public Task<Capital> GetById(int id);
        public Task<Capital> GetByPostalCode(string postalCode);
        public Task<bool> Insert(Capital capital);
        public Task<bool> Update(Capital capital, int id);
    }
}
