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
        public Task<object> QuantityOrdersByMonth(DateTime month);
        public Task<object> ProfitMarginByCategory();
        public Task<object> ProductsMoreThanOneCategory();
        public Task<object> CustomersWithoutOrdersInLastMonth();
        public Task<object> CompareSalesPerYear();
        public Task<object> EmployeesOrdersCustomersFrom5Countries();
        public Task<object> CustomersWithHighValueOrders();
        public Task<object> ProductsDecliningSales();
    }
}
