using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Practica
{
    public interface IPracticaService
    {
        public Task<object> GetDiscontinuedProducts();
        public Task<object> GetDataFromPurchase();
        public Task<object> GetPurchaseQuantityByCustomer();
    }
}
