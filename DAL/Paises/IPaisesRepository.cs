using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Paises
{
    public interface IPaisesRepository
    {
        public Task<ResponseJson> GetAll();
        public Task<ResponseJson> GetById(int id);
        public Task<ResponseJson> GetByAcronimo(string acronimo);
        public Task<ResponseJson> Insert(Paise pais);
        public Task<ResponseJson> Update(Paise pais, int id);
        public Task<ResponseJson> Delete(int id);
    }
}
