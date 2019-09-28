using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public Context db = new Context();

        public ActionResult Index()
        {
            var baskets = from e in db.basket.Include("Product")
                          orderby e.BasketID
                          select e;

            return View(baskets);
        }
        public ActionResult PlaceOrder(int CustomerId)
        {
            var currentBasket = db.basket.Include("Product").Where(xXx => xXx.CustomerId == CustomerId).ToList();
            var currentReserve = db.Reserves.Where(xXx => xXx.CustomerId == CustomerId).ToList();
            var products = db.products;

            ViewData["carts"] = currentBasket;
            Order order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                Carts = currentBasket
            };

            db.Orders.Add(order);


            foreach (var product in products)
            {
                foreach (var sold_product in currentBasket)
                {
                    if (product.ProductId == sold_product.ProductId)
                    {
                        product.ProductStock = Convert.ToInt32(product.ProductStock - sold_product.Quantity);
                    }
                }
            }

            db.basket.RemoveRange(currentBasket);
            db.Reserves.RemoveRange(currentReserve);
            db.SaveChanges();

            return View();

        }
    }
}