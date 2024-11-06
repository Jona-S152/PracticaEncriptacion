using DAL.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Practica
{
    public class PracticaRepository : IPracticaRepository
    {
        private readonly NorthwindContext _northwindContext;

        public PracticaRepository(NorthwindContext context)
        {
            _northwindContext = context;
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
    }
}
