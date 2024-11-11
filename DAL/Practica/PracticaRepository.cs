using DAL.Common;
using DAL.Context;
using Entities.Models;
using Entities.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Practica
{
    public class PracticaRepository : IPracticaRepository
    {
        private readonly NorthwindContext _northwindContext;
        private readonly ConnectionStrings _connectionStrings;

        public PracticaRepository(NorthwindContext context, IOptions<ConnectionStrings> connections)
        {
            _northwindContext = context;
            _connectionStrings = connections.Value;
        }

        public async Task<object> CompareSalesPerYear()
        {
            try
            {
                var result = await (from od in _northwindContext.OrderDetails
                                    join o in _northwindContext.Orders on od.OrderId equals o.OrderId
                                    group new { od, o } by new { o.OrderDate.Value.Month, o.OrderDate.Value.Year} into g
                                    orderby g.Key.Year descending, g.Key.Month ascending
                                    select new
                                    {
                                        Year = g.Key.Year,
                                        Month = g.Key.Month,
                                        Sales = g.Sum( s => s.od.UnitPrice)
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> CustomersWithHighValueOrders()
        {
            try
            {
                var result = await (from c in _northwindContext.Customers
                                    join o in _northwindContext.Orders on c.CustomerId equals o.CustomerId
                                    join od in _northwindContext.OrderDetails on o.OrderId equals od.OrderId
                                    group new { c, o, od } by c.ContactName into g
                                    where g.Sum(x => x.od.Quantity * x.od.UnitPrice) > 10000
                                    select new
                                    {
                                        ContactName = g.Key,
                                        TotalValue = g.Sum(x => x.od.Quantity * x.od.UnitPrice)
                                    }).ToListAsync();

                result = result.OrderByDescending(r => r.TotalValue).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> CustomersWithoutOrdersInLastMonth()
        {
            try
            {
                var top1 = await (from or in _northwindContext.Orders orderby or.OrderDate descending select or.OrderDate).FirstOrDefaultAsync();
                var result = await (from o in _northwindContext.Orders
                                    where o.OrderDate.Value.Year == top1.Value.Year - 1
                                    select o.CustomerId).ToListAsync();

                var newResult = await _northwindContext.Customers.Where(c => !result.Contains(c.CustomerId)).ToListAsync();

                return newResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> EmployeesOrdersCustomersFrom5Countries()
        {
            try
            {
                var OrdersCountryCounts = await (from o in _northwindContext.Orders
                                                 join c in _northwindContext.Customers on o.CustomerId equals c.CustomerId
                                                 join e in _northwindContext.Employees on o.EmployeeId equals e.EmployeeId
                                                 group new {o, c, e} by new { e.FirstName, c.Country} into g
                                                 select new
                                                 {
                                                     CustomerCountry = g.Key.Country,
                                                     EmployeeName = g.Key.FirstName
                                                 }).ToListAsync();

                var result = OrdersCountryCounts.GroupBy(e => e.EmployeeName).Where(e => e.Count() > 5).Select(e => new
                {
                    EmployeeName = e.Key,
                    CountCountries = e.Count()
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> GetDataFromPurchase()
        {
            try
            {
                var data = await (from c in _northwindContext.Customers
                                  join o in _northwindContext.Orders
                                  on c.CustomerId equals o.CustomerId into curstomersOrdersGroup
                                  from o in curstomersOrdersGroup.DefaultIfEmpty()
                                  join od in _northwindContext.OrderDetails
                                  on o.OrderId equals od.OrderId into orderOrderDetailsGroup
                                  from od in orderOrderDetailsGroup.DefaultIfEmpty()
                                  join p in _northwindContext.Products
                                  on od.ProductId equals p.ProductId into orderDetailsProductGroup
                                  from p in orderDetailsProductGroup.DefaultIfEmpty()
                                  select new
                                  {
                                      ContactName = c.ContactName == null ? null : c.ContactName,
                                      ContactTitle = c.ContactTitle == null ? null : c.ContactTitle,
                                      ProductName = p.ProductName == null ? null : p.ProductName,
                                      UnitPrice = od.UnitPrice == null ? 0 : od.UnitPrice
                                  }).ToListAsync();



                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<object> GetDiscontinuedProducts()
        {
            try
            {
                var discontinuedProducts = await (from product in _northwindContext.Products
                                                  join category in _northwindContext.Categories
                                                  on product.CategoryId equals category.CategoryId
                                                  where product.Discontinued == true
                                                  group category by category.CategoryName into discontinuedProduct
                                                  where discontinuedProduct.Count() >= 3
                                                  select new
                                                  {
                                                      categoryName = discontinuedProduct.Key,
                                                      discontinuedProductsNumber = discontinuedProduct.Count()
                                                  }).ToListAsync();

                return discontinuedProducts.OrderByDescending(d => d.discontinuedProductsNumber);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> GetPurchaseQuantityByCustomer()
        {
            try
            {
                var result = await (from o in _northwindContext.Orders
                                    join c in _northwindContext.Customers
                                    on o.CustomerId equals c.CustomerId
                                    join od in _northwindContext.OrderDetails
                                    on o.OrderId equals od.OrderId
                                    where o.ShipCity != null
                                    group od by c.ContactName into purchaseQuantity
                                    where purchaseQuantity.Sum(p => p.Quantity * p.UnitPrice) > 14
                                    select new
                                    {
                                        ContactName = purchaseQuantity.Key,
                                        PurchaseQuantity = purchaseQuantity.Count()
                                    }).ToListAsync();

                return result.OrderByDescending(r => r.PurchaseQuantity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<object> ProductsDecliningSales()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> ProductsMoreThanOneCategory()
        {
            try
            {
                var result = await (from o in _northwindContext.Orders
                                    join od in _northwindContext.OrderDetails on o.OrderId equals od.OrderId
                                    join p in _northwindContext.Products on od.ProductId equals p.ProductId
                                    join c in _northwindContext.Categories on p.CategoryId equals c.CategoryId
                                    group new { o, c } by o.OrderId into g
                                    where g.Select(x => x.c.CategoryId).Distinct().Count() > 1
                                    select g.Key).ToListAsync();

                var newResult = await _northwindContext.Orders.Where(o => result.Contains(o.OrderId)).ToListAsync();

                return newResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> ProfitMarginByCategory()
        {
            try
            {
                var result = await (from p in _northwindContext.Products
                                    orderby (p.UnitPrice * p.UnitsInStock) ascending
                                    select new
                                    {
                                        ProductName = p.ProductName,
                                        ProfitMargin = p.UnitPrice * p.UnitsInStock
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<object> QuantityOrdersByMonth(DateTime date)
        {
            try
            {
                DateTime orderDate;

                var result = await (from c in _northwindContext.Customers
                                    join o in _northwindContext.Orders on c.CustomerId equals o.CustomerId
                                    where o.OrderDate.Value.Month == date.Month && o.OrderDate.Value.Year == date.Year
                                    group c by c.CustomerId into customerOrder
                                    orderby customerOrder.Count() descending
                                    select new
                                    {
                                        CustomerID = customerOrder.Key,
                                        OrdersQuantity = customerOrder.Count()
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
