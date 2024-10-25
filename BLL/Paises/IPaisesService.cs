using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Paises
{
    public interface IPaisesService
    {
        public Task<ResponseJson> GetAll();
        public Task<ResponseJson> GetById(int id);
        public Task<ResponseJson> GetByAcronimo(string acronimo);
        public Task<ResponseJson> GetByAcronimoStartsWith(string acronimo);
        public Task<ResponseJson> GetOrderByAcronimoDESC();
        public Task<ResponseJson> Insert(Paise pais);
        public Task<ResponseJson> Update(Paise pais, int id);
    }
}
